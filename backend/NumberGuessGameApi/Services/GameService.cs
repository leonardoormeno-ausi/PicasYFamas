using NumberGuessGameApi.Data;
using NumberGuessGameApi.DTOs;
using Microsoft.EntityFrameworkCore;
using NumberGuessGameApi.Models;
using NumberGuessGameApi.Helpers;
using NumberGuessGameApi.Security;

namespace NumberGuessGameApi.Services;

public class GameService : IGameService
{
    private readonly GameDbContext _context;
    private readonly IConfiguration _configuration;

    public GameService(GameDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<RegisterPlayerResponse> RegisterPlayerAsync(RegisterPlayerRequest request)
    {
        var emailExiste = await _context.Players
            .AnyAsync(p => p.Email == request.Email);

        if (emailExiste)
        {
            throw new Exception("El correo electrónico ya está registrado.");
        }

        var player = new Player
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            Email = request.Email,
            PasswordHash = PasswordHelper.HashPassword(request.Password)
        };

        _context.Players.Add(player);

        await _context.SaveChangesAsync();

        var token = JwtHelper.GenerateToken(player, _configuration);

        return new RegisterPlayerResponse
        {
            Token = token
        };
    }

    // ← ESTE MÉTODO ES EL NUEVO
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var player = await _context.Players
            .FirstOrDefaultAsync(p => p.Email == request.Email);

        if (player == null)
        {
            throw new Exception("Correo o contraseña incorrectos.");
        }

        var passwordValida = PasswordHelper.VerifyPassword(
            request.Password,
            player.PasswordHash);

        if (!passwordValida)
        {
            throw new Exception("Correo o contraseña incorrectos.");
        }

        var token = JwtHelper.GenerateToken(player, _configuration);

        return new LoginResponse
        {
            Token = token
        };
    }
    public async Task<CreateGameResponse> CreateGameAsync(int playerId)
    {
        var player = await _context.Players
            .FirstOrDefaultAsync(p => p.Id == playerId);

        if (player == null)
        {
            throw new Exception("El jugador no existe.");
        }

        var random = new Random();

        var digits = Enumerable.Range(0, 10)
            .OrderBy(x => random.Next())
            .Take(4);

        var secretNumber = string.Concat(digits);

        var game = new Game
        {
            PlayerId = playerId,
            SecretNumber = secretNumber,
            Status = GameStatus.Active
        };

        _context.Games.Add(game);

        await _context.SaveChangesAsync();

        return new CreateGameResponse
        {
            GameId = game.Id,
            Message = "Partida creada correctamente."
        };
    }
    public async Task<GuessResponse> GuessAsync(int playerId, GuessRequest request)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g =>
                g.Id == request.GameId &&
                g.PlayerId == playerId);

        if (game == null)
        {
            throw new Exception("La partida no existe o no pertenece al jugador.");
        }

        if (game.Status != GameStatus.Active)
        {
            throw new Exception("La partida ya finalizó.");
        }

        var result = GameEngine.Calculate(
            game.SecretNumber,
            request.Number);

        var attempt = new Attempt
        {
            GameId = game.Id,
            AttemptedNumber = request.Number,
            Picas = result.picas,
            Famas = result.famas
        };

        _context.Attempts.Add(attempt);

        if (result.famas == 4)
        {
            game.Status = GameStatus.Finished;
            game.FinishedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        return new GuessResponse
        {
            Picas = result.picas,
            Famas = result.famas,
            IsWinner = result.famas == 4,
            Message = result.famas == 4
                ? "¡Felicitaciones! Adivinaste el número."
                : $"Obtuviste {result.picas} Picas y {result.famas} Famas."
        };
    }
    public async Task<List<GameHistoryResponse>> GetHistoryAsync(int playerId)
    {
        var games = await _context.Games
            .Where(g => g.PlayerId == playerId)
            .Include(g => g.Attempts)
            .OrderByDescending(g => g.CreatedAt)
            .Select(g => new GameHistoryResponse
            {
                GameId = g.Id,
                Status = g.Status.ToString(),
                CreatedAt = g.CreatedAt,
                FinishedAt = g.FinishedAt,
                Attempts = g.Attempts.Count
            })
            .ToListAsync();

        return games;
    }
    public async Task<List<AttemptHistoryResponse>> GetAttemptsHistoryAsync(int playerId, int gameId)
    {
        var game = await _context.Games
            .Include(g => g.Attempts)
            .FirstOrDefaultAsync(g =>
                g.Id == gameId &&
                g.PlayerId == playerId);

        if (game == null)
        {
            throw new Exception("La partida no existe o no pertenece al jugador.");
        }

        return game.Attempts
            .OrderBy(a => a.AttemptDate)
            .Select(a => new AttemptHistoryResponse
            {
                AttemptedNumber = a.AttemptedNumber,
                Picas = a.Picas,
                Famas = a.Famas,
                AttemptDate = a.AttemptDate
            })
            .ToList();
    }
    public async Task<PlayerStatsResponse> GetPlayerStatsAsync(int playerId)
    {
        var games = await _context.Games
            .Include(g => g.Attempts)
            .Where(g => g.PlayerId == playerId)
            .ToListAsync();

        var gamesPlayed = games.Count;

        var gamesWon = games.Count(g => g.Status == GameStatus.Finished);

        var activeGames = games.Count(g => g.Status == GameStatus.Active);

        var averageAttempts = gamesPlayed == 0
            ? 0
            : games.Average(g => g.Attempts.Count);

        var finishedGames = games
        .Where(g => g.Status == GameStatus.Finished)
        .ToList();

        int? bestGameAttempts = null;

        if (finishedGames.Any())
        {
            bestGameAttempts = finishedGames
                .Min(g => g.Attempts.Count);
        }

        return new PlayerStatsResponse
        {
            GamesPlayed = gamesPlayed,
            GamesWon = gamesWon,
            ActiveGames = activeGames,
            AverageAttempts = Math.Round(averageAttempts, 2),
            BestGameAttempts = bestGameAttempts
        };
    }
}
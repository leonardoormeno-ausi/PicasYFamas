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
public async Task<CreateGameResponse> CreateGameAsync(CreateGameRequest request)
{
    var player = await _context.Players
        .FirstOrDefaultAsync(p => p.Id == request.PlayerId);

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
        PlayerId = request.PlayerId,
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
public async Task<GuessResponse> GuessAsync(GuessRequest request)
{
    var game = await _context.Games
        .FirstOrDefaultAsync(g => g.Id == request.GameId);

    if (game == null)
    {
        throw new Exception("La partida no existe.");
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
}
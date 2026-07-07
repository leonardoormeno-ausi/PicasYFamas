using NumberGuessGameApi.Data;
using NumberGuessGameApi.DTOs;
using Microsoft.EntityFrameworkCore;
using NumberGuessGameApi.Models;
using NumberGuessGameApi.Helpers;

namespace NumberGuessGameApi.Services;

public class GameService : IGameService
{
    private readonly GameDbContext _context;

    public GameService(GameDbContext context)
    {
        _context = context;
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

        // Más adelante reemplazaremos esto por un hash
        PasswordHash = PasswordHelper.HashPassword(request.Password)
    };

    _context.Players.Add(player);

    await _context.SaveChangesAsync();

    return new RegisterPlayerResponse
    {
        Token = "TOKEN_PROVISORIO"
    };
}
}
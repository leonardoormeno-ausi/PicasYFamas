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

        // Más adelante reemplazaremos esto por un hash
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
}
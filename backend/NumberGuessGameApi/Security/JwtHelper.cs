using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NumberGuessGameApi.Models;

namespace NumberGuessGameApi.Security;

public static class JwtHelper
{
    public static string GenerateToken(Player player, IConfiguration configuration)
    {
        var key = configuration["Jwt:Key"]!;

        var issuer = configuration["Jwt:Issuer"]!;

        var audience = configuration["Jwt:Audience"]!;

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, player.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, player.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName,
                $"{player.FirstName} {player.LastName}")
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
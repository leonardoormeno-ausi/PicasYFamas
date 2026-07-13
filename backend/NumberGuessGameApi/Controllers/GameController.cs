using Microsoft.AspNetCore.Mvc;
using NumberGuessGameApi.DTOs;
using NumberGuessGameApi.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace NumberGuessGameApi.Controllers;

[ApiController]
[Route("api/game/v1")]
[Authorize]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterPlayerRequest request)
    {
        var response = await _gameService.RegisterPlayerAsync(request);

        return Ok(response);
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _gameService.LoginAsync(request);

        return Ok(response);
    }
    [HttpPost("new-game")]
public async Task<IActionResult> CreateGame()
{
    var playerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

    if (playerIdClaim == null)
    {
        return Unauthorized();
    }

    var playerId = int.Parse(playerIdClaim.Value);

    var response = await _gameService.CreateGameAsync(playerId);

    return Ok(response);
}
    [HttpPost("guess")]
public async Task<IActionResult> Guess(GuessRequest request)
{
    var response = await _gameService.GuessAsync(request);

    return Ok(response);
}
[HttpGet("history")]
public async Task<IActionResult> GetHistory()
{
    var playerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

    if (playerIdClaim == null)
    {
        return Unauthorized();
    }

    var playerId = int.Parse(playerIdClaim.Value);

    var response = await _gameService.GetHistoryAsync(playerId);

    return Ok(response);
}
}
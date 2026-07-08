using Microsoft.AspNetCore.Mvc;
using NumberGuessGameApi.DTOs;
using NumberGuessGameApi.Services;

namespace NumberGuessGameApi.Controllers;

[ApiController]
[Route("api/game/v1")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterPlayerRequest request)
    {
        var response = await _gameService.RegisterPlayerAsync(request);

        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _gameService.LoginAsync(request);

        return Ok(response);
    }
}
using NumberGuessGameApi.DTOs;

namespace NumberGuessGameApi.Services;

public interface IGameService
{
    Task<RegisterPlayerResponse> RegisterPlayerAsync(RegisterPlayerRequest request);
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<CreateGameResponse> CreateGameAsync(CreateGameRequest request);
    Task<GuessResponse> GuessAsync(GuessRequest request);
}
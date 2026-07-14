using NumberGuessGameApi.DTOs;

namespace NumberGuessGameApi.Services;

public interface IGameService
{
    Task<RegisterPlayerResponse> RegisterPlayerAsync(RegisterPlayerRequest request);
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<CreateGameResponse> CreateGameAsync(int playerId);
    Task<GuessResponse> GuessAsync(GuessRequest request);
    Task<List<GameHistoryResponse>> GetHistoryAsync(int playerId);
    Task<List<AttemptHistoryResponse>> GetAttemptsHistoryAsync(int playerId, int gameId);
    Task<PlayerStatsResponse> GetPlayerStatsAsync(int playerId);
}
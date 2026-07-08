namespace NumberGuessGameApi.DTOs;

public class CreateGameResponse
{
    public int GameId { get; set; }

    public string Message { get; set; } = string.Empty;
}
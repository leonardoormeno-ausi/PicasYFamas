namespace NumberGuessGameApi.DTOs;

public class GameHistoryResponse
{
    public int GameId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public int Attempts { get; set; }
}
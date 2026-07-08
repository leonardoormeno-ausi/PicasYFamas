namespace NumberGuessGameApi.DTOs;

public class GuessRequest
{
    public int GameId { get; set; }

    public string Number { get; set; } = string.Empty;
}
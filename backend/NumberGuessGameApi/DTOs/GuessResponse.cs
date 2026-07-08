namespace NumberGuessGameApi.DTOs;

public class GuessResponse
{
    public int Picas { get; set; }

    public int Famas { get; set; }

    public bool IsWinner { get; set; }

    public string Message { get; set; } = string.Empty;
}
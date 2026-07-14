namespace NumberGuessGameApi.DTOs;

public class AttemptHistoryResponse
{
    public string AttemptedNumber { get; set; } = string.Empty;

    public int Picas { get; set; }

    public int Famas { get; set; }

    public DateTime AttemptDate { get; set; }
}
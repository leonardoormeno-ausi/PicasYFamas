namespace NumberGuessGameApi.DTOs;

public class PlayerStatsResponse
{
    public int GamesPlayed { get; set; }

    public int GamesWon { get; set; }

    public int ActiveGames { get; set; }

    public double AverageAttempts { get; set; }

    public int BestGameAttempts { get; set; }
}
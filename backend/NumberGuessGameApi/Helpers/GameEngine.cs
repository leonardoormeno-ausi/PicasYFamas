namespace NumberGuessGameApi.Helpers;

public static class GameEngine
{
    public static (int picas, int famas) Calculate(
        string secretNumber,
        string attemptedNumber)
    {
        int picas = 0;
        int famas = 0;

        for (int i = 0; i < secretNumber.Length; i++)
        {
            if (attemptedNumber[i] == secretNumber[i])
            {
                famas++;
            }
            else if (secretNumber.Contains(attemptedNumber[i]))
            {
                picas++;
            }
        }

        return (picas, famas);
    }
}
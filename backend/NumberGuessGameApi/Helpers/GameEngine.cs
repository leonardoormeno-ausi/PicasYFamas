namespace NumberGuessGameApi.Helpers;

public static class GameEngine
{
    public static (int picas, int famas) Calculate(
        string secretNumber,
        string attemptedNumber)
    {
        if (string.IsNullOrWhiteSpace(attemptedNumber))
            throw new Exception("Debe ingresar un número.");

        if (attemptedNumber.Length != 4)
            throw new Exception("El número debe tener exactamente 4 dígitos.");

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
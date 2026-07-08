namespace NumberGuessGameApi.Models;

public class Attempt
{
    public int Id { get; set; }

    // Juego al que pertenece
    public int GameId { get; set; }

    // Propiedad de navegación
    public Game Game { get; set; } = null!;

    // Número enviado por el jugador
    public string AttemptedNumber { get; set; } = string.Empty;

    // Cantidad de Picas
    public int Picas { get; set; }

    // Cantidad de Famas
    public int Famas { get; set; }

    // Fecha del intento
    public DateTime AttemptDate { get; set; } = DateTime.UtcNow;
}
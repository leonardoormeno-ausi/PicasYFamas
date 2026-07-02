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

    // Respuesta del GameCore
    public string Message { get; set; } = string.Empty;

    // Fecha del intento
    public DateTime AttemptDate { get; set; } = DateTime.UtcNow;
}
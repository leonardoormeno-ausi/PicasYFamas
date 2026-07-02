namespace NumberGuessGameApi.Models;

public class Game
{
    public int Id { get; set; }

    // Clave foránea hacia Player
    public int PlayerId { get; set; }

    // Propiedad de navegación
    public Player Player { get; set; } = null!;

    // Número secreto del juego
    public string SecretNumber { get; set; } = string.Empty;

    // Estado del juego
    public GameStatus Status { get; set; } = GameStatus.Active;

    // Fecha de creación
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Fecha de finalización (puede ser nula)
    public DateTime? FinishedAt { get; set; }

    // Relación con los intentos
    public ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();
}
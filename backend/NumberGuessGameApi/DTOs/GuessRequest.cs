using System.ComponentModel.DataAnnotations;

namespace NumberGuessGameApi.DTOs;

public class GuessRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "El identificador de la partida es inválido.")]
    public int GameId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un número.")]
    [RegularExpression(@"^\d{4}$",
        ErrorMessage = "El número debe tener exactamente 4 dígitos.")]
    public string Number { get; set; } = string.Empty;
}
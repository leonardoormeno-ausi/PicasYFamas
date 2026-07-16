using System.ComponentModel.DataAnnotations;

namespace NumberGuessGameApi.DTOs;

public class GuessRequest
{
    [Required(ErrorMessage = "El Id de la partida es obligatorio.")]
    public int GameId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un número.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "El número debe contener exactamente 4 dígitos.")]
    public string Number { get; set; } = string.Empty;
}
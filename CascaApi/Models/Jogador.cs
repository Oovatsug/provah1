using System.ComponentModel.DataAnnotations;

namespace CascaApi.Models;

public class jogador
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Range(1, 8)]
    public int Turma { get; set; }

    [Required]
    [StringLength(500)]
    public string DescricaoProposta { get; set; } = string.Empty;

    [Range(10, 99)]
    public int Numero { get; set; }
}

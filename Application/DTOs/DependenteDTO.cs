using System.ComponentModel.DataAnnotations;

namespace ZAlert.Api.Application.DTOs;

public class DependenteDto
{
    [MaxLength(100)]
    public string? NmDepen { get; set; }

    [MaxLength(30)]
    public string? Tipo { get; set; }

    public int? IdadeDepen { get; set; }

    [Required]
    public int UsuarioId { get; set; }
}
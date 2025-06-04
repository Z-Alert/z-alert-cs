using System.ComponentModel.DataAnnotations;

namespace ZAlert.Api.Application.DTOs;

public class DispositivoDto
{
    [MaxLength(50)]
    public string? TipoDisposit { get; set; }

    [MaxLength(20)]
    public string? StatusDisposit { get; set; }

    [Required]
    public int DependenteId { get; set; }
}
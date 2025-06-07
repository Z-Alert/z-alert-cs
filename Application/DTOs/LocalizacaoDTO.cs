using System.ComponentModel.DataAnnotations;

namespace ZAlert.Api.Application.DTOs;

public class LocalizacaoDto
{
    [Required]
    [Range(-90, 90)]
    public decimal LatLocali { get; set; }

    [Required]
    [Range(-180, 180)]
    public decimal LngLocali { get; set; }

    [Required]
    public int DependenteId { get; set; }
}
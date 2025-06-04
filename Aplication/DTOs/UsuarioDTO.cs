using System.ComponentModel.DataAnnotations;

namespace ZAlert.Api.Application.DTOs;

public class UsuarioDto
{
    [MaxLength(60)]
    public string? NmUsu { get; set; }

    [EmailAddress]
    [MaxLength(100)]
    public string? EmailUsu { get; set; }

    [MaxLength(100)]
    public string? SenhaUsu { get; set; }
}

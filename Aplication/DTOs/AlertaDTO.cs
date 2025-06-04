using System.ComponentModel.DataAnnotations;

namespace ZAlert.Api.Application.DTOs;

public class AlertaDto
{
	[MaxLength(255)]
	public string? Localizacao { get; set; }

	[MaxLength(50)]
	public string? SttsAlerta { get; set; }

	[Required]
	public int DependenteId { get; set; }
}

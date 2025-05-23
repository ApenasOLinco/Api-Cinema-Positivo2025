namespace Cinema_Api.src.Models.DTOs;

public record DiretorDTO(string Nome, DateOnly DataNasc, string? Biografia)
{
	public DiretorDTO()
		: this("", default, null) { }
}

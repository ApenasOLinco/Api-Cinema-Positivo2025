namespace Cinema_Api.src.Models.DTOs.Get;

public record AtorGetDTO(string Nome, DateOnly DataNascimento)
{
	public AtorGetDTO()
		: this("", default) { }
}

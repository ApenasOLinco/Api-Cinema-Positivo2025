namespace Cinema_Api.src.Models.DTOs.Filter;

public class FilmeFilterDTO
{
	public string? Titulo { get; set; }

	public int? AnoLancamento { get; set; }

	public string? Sinopse { get; set; }

	public List<Genero>? Generos { get; set; }

	public Diretor? Diretor { get; set; }
}
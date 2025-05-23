namespace Cinema_Api.src.Models.DTOs;

public class FilmeDTO
{
	public required string Titulo { get; set; }

	public required int AnoLancamento { get; set; }

	public required string Sinopse { get; set; }

	public required float NotaIMDB { get; set; }

	public required List<string> Generos { get; set; }

	public required DiretorDTO Diretor { get; set; }
}

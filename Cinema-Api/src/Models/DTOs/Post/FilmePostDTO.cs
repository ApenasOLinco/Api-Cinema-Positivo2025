using Cinema_Api.src.Models.DTOs.Get;

namespace Cinema_Api.src.Models.DTOs.Post;

public class FilmePostDTO
{
	public required String Titulo  { get; set; }

	public required int AnoLancamento { get; set; }

	public required string Sinopse { get; set; }

	public required float NotaIMDB { get; set; }

	public required List<string> Generos { get; set; }

	public required DiretorGetDTO Diretor { get; set; }
}

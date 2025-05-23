namespace Cinema_Api.src.Models.DTOs;

public record FilmeDTO(
	string Titulo,
	int AnoLancamento,
	string Sinopse,
	float NotaIMDB,
	List<string> Generos,
	DiretorDTO Diretor
)
{
	public FilmeDTO()
		: this("", default, "", default, [], null!) { }
}

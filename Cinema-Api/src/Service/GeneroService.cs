using Cinema_Api.src.Context;
using Cinema_Api.src.Exceptions;
using Cinema_Api.src.Models;

namespace Cinema_Api.src.Service;

public class GeneroService(MasterContext masterContext)
{
	private readonly MasterContext _masterContext = masterContext;

	/// <summary>
	/// Cria um novo gênero, se o gênero fornecido ainda não
	/// existir no banco de dados.
	/// </summary>
	/// <param name="nomeGenero">O nome do gênero a ser criado</param>
	/// <returns>O gênero criado</returns>
	/// <exception cref="Quando o gênero fornecido já existe - AlreadyExistsException"></exception>
	public Genero NovoGenero(string nomeGenero)
	{
		var existe =
			_masterContext.Genero.FirstOrDefault(g => g.Nome.Equals(nomeGenero)) is not null;

		if (existe)
			throw new AlreadyExistsException(
				$"O gênero de nome {nomeGenero} já existe no banco de dados."
			);

		Genero genero = new() { Nome = nomeGenero };
		_masterContext.Genero.Add(genero);
		_masterContext.SaveChanges();

		return genero;
	}

	public Genero GetExistenteOuCriar(string nome) // TODO trocar string por GeneroDTO quando a classe for criada
	{
		var genero = SingleByNome(nome);

		genero ??= CriarGeneroSemVerificar(nome); // Se for nulo, cria um novo

		return genero;
	}

	private Genero? SingleByNome(string nome)
	{
		return _masterContext
			.Genero.AsEnumerable()
			.FirstOrDefault(g => g.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
	}

	private Genero CriarGeneroSemVerificar(string nome)
	{
		var novoGenero = new Genero() { Nome = nome };

		_masterContext.Genero.Add(novoGenero);
		_masterContext.SaveChanges();
		return novoGenero;
	}
}

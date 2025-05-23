using Cinema_Api.src.Context;
using Cinema_Api.src.Models;

namespace Cinema_Api.src.Service;

public class GeneroService(MasterContext masterContext)
{
	private readonly MasterContext _masterContext = masterContext;

	/// <summary>
	/// Cria um novo gênero, se o gênero fornecido ainda não
	/// existir no banco de dados.
	/// </summary>
	/// <param name="genero">O nome do gênero a ser criado</param>
	/// <returns>O gênero criado, ou <c>null</c> caso ele já exista</returns>
	public string? NovoGenero(string genero)
	{
		var existe = _masterContext.Genero.FirstOrDefault(g => g.Nome.Equals(genero)) is not null;

		if (existe)
			return null;

		_masterContext.Genero.Add(new Genero { Nome = genero });

		return genero;
	}
}

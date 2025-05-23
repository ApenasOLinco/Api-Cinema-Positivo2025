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
	/// <param name="nomeGenero">O nome do gênero a ser criado</param>
	/// <returns>O gênero criado, ou <c>null</c> caso ele já exista</returns>
	public Genero? NovoGenero(string nomeGenero)
	{
		var existe =
			_masterContext.Genero.FirstOrDefault(g => g.Nome.Equals(nomeGenero)) is not null;

		if (existe)
			return null;

		Genero genero = new() { Nome = nomeGenero };
		_masterContext.Genero.Add(genero);
		_masterContext.SaveChanges();

		return genero;
	}
}

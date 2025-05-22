using Cinema_Api.src.Context;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs;

namespace Cinema_Api.src.Service;

public class DiretorService(MasterContext masterContext)
{
	private readonly MasterContext _masterContext = masterContext;

	public Diretor? SingleByNomeAndDataNascimento(string nome, DateOnly dataNascimento)
	{
		return _masterContext.Diretor.First(d =>
			d.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)
			&& d.DataNascimento.Equals(dataNascimento)
		);
	}

	public Diretor? NovoDiretor(DiretorDTO diretor)
	{
		var existe =
			SingleByNomeAndDataNascimento(diretor.Nome, diretor.DataNascimento) is not null;

		if (existe)
			return null;

		var novoDiretor = new Diretor
		{
			Nome = diretor.Nome,
			DataNascimento = diretor.DataNascimento,
			Biografia = diretor.Biografia!,
		};

		_masterContext.Diretor.Add(novoDiretor);
		_masterContext.SaveChanges();
		return novoDiretor;
	}
}

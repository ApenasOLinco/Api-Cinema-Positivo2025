using Cinema_Api.src.Context;
using Cinema_Api.src.Exceptions;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs;

namespace Cinema_Api.src.Service;

public class DiretorService(MasterContext masterContext)
{
	private readonly MasterContext _masterContext = masterContext;

	public Diretor NovoDiretor(DiretorDTO diretor)
	{
		var existe = SingleByNomeAndDataNasc(diretor.Nome, diretor.DataNasc) is not null;

		if (existe)
			throw new AlreadyExistsException(
				"Uma entidade Diretor com Nome e Data de Nascimento iguais ao fornecido já existe."
			);

		Diretor novoDiretor = CriarDiretorSemVerificar(diretor);
		return novoDiretor;
	}

	public Diretor GetExistenteOuCriar(DiretorDTO dto)
	{
		var diretor = SingleByNomeAndDataNasc(dto.Nome, dto.DataNasc);

		diretor ??= CriarDiretorSemVerificar(dto); // Se for nulo, cria um novo

		return diretor;
	}

	public Diretor? SingleByNomeAndDataNasc(string nome, DateOnly dataNasc)
	{
		return _masterContext
			.Diretor.AsEnumerable()
			.FirstOrDefault(d =>
				d.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)
				&& d.DataNasc.Equals(dataNasc)
			);
	}

	#region Métodos Privados

	private Diretor CriarDiretorSemVerificar(DiretorDTO diretor)
	{
		var novoDiretor = new Diretor
		{
			Nome = diretor.Nome,
			DataNasc = diretor.DataNasc,
			Biografia = diretor.Biografia!,
		};

		_masterContext.Diretor.Add(novoDiretor);
		_masterContext.SaveChanges();
		return novoDiretor;
	}

	#endregion
}

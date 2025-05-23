using AutoMapper;
using Cinema_Api.src.Context;
using Cinema_Api.src.Exceptions;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs;
using Cinema_Api.src.Models.DTOs.HttpPatch;
using Cinema_Api.src.Models.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Api.src.Service;

public class FilmesService(
	MasterContext masterContext,
	GeneroService generoService,
	DiretorService diretorService
)
{
	private readonly MasterContext _masterContext = masterContext;

	private readonly GeneroService _generoService = generoService;

	private readonly DiretorService _diretorService = diretorService;

	// Ferramenta que transforma objetos de um tipo para objetos de outro
	private readonly Mapper Mapper = new(new MapperConfiguration(AutoMapperConfig.Configurar));

	public List<FilmeDTO> TodosOsFilmes()
	{
		var filmes = _masterContext
			.Filme.Include(f => f.FilmesGeneros)
			.ThenInclude(fg => fg.Genero)
			.Include(f => f.Diretor)
			.Select(f => Mapper.Map<Filme, FilmeDTO>(f))
			.ToList();

		return filmes;
	}

	public FilmeDTO UmFilme(int id)
	{
		var filme = _masterContext
			.Filme.Include(f => f.FilmesGeneros)
			.ThenInclude(fg => fg.Genero)
			.Include(f => f.Diretor)
			.Where(f => f.Id == id)
			.FirstOrDefault();

		return filme is null
			? throw new EntityNotFoundException($"Uma entidade Filme de Id {id} não existe.")
			: Mapper.Map<Filme, FilmeDTO>(filme);
	}

	public Filme NovoFilme(FilmeDTO filmeDto)
	{
		foreach (string dtoGenero in filmeDto.Generos)
		{
			_generoService.NovoGenero(dtoGenero);
		}

		// Verifica se um filme com mesmo título e
		// ano de lançamento já existe no banco de dados
		var existe = _masterContext
			.Filme.Where(filmeBd =>
				filmeBd.Titulo.ToLower().Equals(filmeDto.Titulo.ToLower())
				&& filmeBd.AnoLancamento == filmeDto.AnoLancamento
			)
			.Any();

		if (existe)
			throw new AlreadyExistsException(
				"Uma entidade Filme com título e data de lançamento iguais aos fornecidos já existe."
			);

		var diretor = _diretorService.GetExistenteOuCriar(filmeDto.Diretor);

		var filme = Mapper.Map<FilmeDTO, Filme>(filmeDto);

		_masterContext.Filme.Add(filme);
		_masterContext.SaveChanges();

		return filme;
	}

	public FilmeDTO ModificarFilme(int id, FilmePatchDTO patchDto)
	{
		var filme = _masterContext
			.Filme.Include(filme => filme.FilmesGeneros)
			.ThenInclude(fg => fg.Genero)
			.Include(filme => filme.Diretor)
			.First(filme => filme.Id == id);

		if (patchDto.Titulo is not null)
			filme.Titulo = patchDto.Titulo;

		if (patchDto.AnoLancamento is not null)
			filme.AnoLancamento = patchDto.AnoLancamento.Value;

		if (patchDto.NotaIMDB is not null)
			filme.NotaIMDB = patchDto.NotaIMDB.Value;

		if (patchDto.Generos is not null)
		{
			// Remove os filmesGeneros do objeto filme para substituí-los
			filme.FilmesGeneros.Clear();

			foreach (var nomeGenero in patchDto.Generos) // Efetivamente Adiciona os novos gêneros ao filme..,
			{
				var genero = _generoService.GetExistenteOuCriar(nomeGenero);
				filme.FilmesGeneros.Add(new() { FilmeId = filme.Id, GeneroId = genero.Id });
			}
		}

		if (patchDto.Diretor is null)
		{
			_masterContext.SaveChanges();
			return Mapper.Map<Filme, FilmeDTO>(filme); // Não há necessidade de modificar o diretor, então retorna
		}

		if (patchDto.IsNovoDiretor is null) // Diretor foi fornecido, então IsNovoDiretor deve ser fornecido também
		{
			throw new BadHttpRequestException(
				"Se um diretor for fornecido, é necessário especificar se "
					+ "ele deve ser interpretado como um diretor novo através da "
					+ "propriedade \"IsNovoDiretor\" (true ou false)"
			);
		}

		if (patchDto.IsNovoDiretor.Value)
		{
			// É um novo diretor, então adiciona ele à database
			var diretor = _diretorService.NovoDiretor(patchDto.Diretor);

			filme.Diretor = diretor;
		}
		else
		{
			var diretor = _diretorService.SingleByNomeAndDataNascimento(
				patchDto.Diretor.Nome,
				patchDto.Diretor.DataNasc
			);

			filme.Diretor = diretor ?? filme.Diretor;
		}

		_masterContext.SaveChanges();
		return Mapper.Map<Filme, FilmeDTO>(filme);
	}

	public void DeletarFilme(int id)
	{
		var filme =
			_masterContext.Filme.FirstOrDefault(f => f.Id == id)
			?? throw new EntityNotFoundException($"Uma entidade Filme de id {id} não existe.");

		_masterContext.Filme.Remove(_masterContext.Filme.First(f => f.Id == id));
		_masterContext.SaveChanges();
	}
}

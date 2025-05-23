using AutoMapper;
using Cinema_Api.src.Context;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs;
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

	public List<FilmeDTO> AllFilmes()
	{
		var filmes = _masterContext
			.Filme.Include(f => f.FilmesGeneros)
			.ThenInclude(fg => fg.Genero)
			.Include(f => f.Diretor)
			.Select(f => Mapper.Map<Filme, FilmeDTO>(f))
			.ToList();

		return filmes;
	}

	public FilmeDTO? SingleFilme(int id)
	{
		var filme = _masterContext
			.Filme.Include(f => f.FilmesGeneros)
			.ThenInclude(fg => fg.Genero)
			.Include(f => f.Diretor)
			.Where(f => f.Id == id)
			.Select(f => Mapper.Map<Filme, FilmeDTO>(f))
			.FirstOrDefault();

		return filme;
	}

	public Filme? NovoFilme(FilmeDTO filmeDto)
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
			return null;

		var diretor = _diretorService.GetExistenteOuCriar(filmeDto.Diretor);

		var filme = Mapper.Map<FilmeDTO, Filme>(filmeDto);

		_masterContext.Filme.Add(filme);
		_masterContext.SaveChanges();

		return filme;
	}

	public void DeletarFilme(int id)
	{
		var filme =
			_masterContext.Filme.FirstOrDefault(f => f.Id == id)
			?? throw new EntityNotFoundException($"A entidade Filme de id {id} não existe.");

		_masterContext.Filme.Remove(_masterContext.Filme.First(f => f.Id == id));
		_masterContext.SaveChanges();
	}
}

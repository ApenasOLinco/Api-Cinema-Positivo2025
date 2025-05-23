using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs;
using Cinema_Api.src.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Api.src.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FilmesController(FilmesService service) : ControllerBase
{
	private FilmesService FilmesService { get; } = service;

	[HttpGet]
	public ActionResult<List<FilmeDTO>> AllFilmes()
	{
		var filmes = FilmesService.AllFilmes();

		return Ok(filmes);
	}

	[HttpGet("{id}")]
	public ActionResult<FilmeDTO> SingleFilme(int id)
	{
		var filme = FilmesService.SingleFilme(id);

		return Ok(filme);
	}

	[HttpPost]
	public ActionResult<FilmeDTO> NovoFilme([FromBody] FilmeDTO filme)
	{
		var filmeCriado = FilmesService.NovoFilme(filme);

		if (filmeCriado is null)
		{
			return Conflict("O filme já existe no banco de dados.");
		}

		return CreatedAtAction(nameof(SingleFilme), new { filmeCriado.Id });
	}
}

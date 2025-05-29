using Cinema_Api.src.Models.DTOs.Filter;
using Cinema_Api.src.Models.DTOs.Get;
using Cinema_Api.src.Models.DTOs.HttpPatch;
using Cinema_Api.src.Models.DTOs.Post;
using Cinema_Api.src.Service;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior;

namespace Cinema_Api.src.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FilmesController(FilmeService service) : ControllerBase
{
	private FilmeService FilmesService { get; } = service;


	[HttpPost]
	public ActionResult<FilmeGetDTO> NovoFilme([FromBody] FilmePostDTO filme)
	{
		var filmeCriado = FilmesService.NovoFilme(filme);

		if (filmeCriado is null)
		{
			return Conflict("O filme já existe no banco de dados.");
		}

		// Trocar por Created(), vazio mesmo
		return CreatedAtAction(nameof(UmFilme), new { id = filmeCriado.Id }, filme);
	}

	[HttpDelete("{id}")]
	public ActionResult DeletarFilme([FromRoute(Name = "id")] int id)
	{
		FilmesService.DeletarFilme(id);

		return NoContent();
	}
}

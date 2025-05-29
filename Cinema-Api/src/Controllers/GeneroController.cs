using Cinema_Api.src.Models.DTOs.Filter;
using Cinema_Api.src.Models.DTOs.Get;
using Cinema_Api.src.Models.DTOs.HttpPatch;
using Cinema_Api.src.Models.DTOs.Post;
using Cinema_Api.src.Service;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior;

namespace Cinema_Api.src.Controllers;

public class GeneroController(GeneroService service) : ControllerBase
{
	private GeneroService GeneroService { get; } = service;

	[HttpPost]
	public ActionResult<GeneroGetDTO> NovoGenero([FromBody] GeneroPostDTO genero)
	{
		var generoCriado = GeneroService.NovoGenero(genero);

		if (generoCriado is null)
		{
			return Conflict("O genero já existe no banco de dados.");
		}

		// Trocar por Created(), vazio mesmo
		return Created();
	}

	[HttpDelete]
	public ActionResult DeletarGenero(int Id)
	{
		GeneroService.DeletarGenero(Id);

		return NoContent();
	}
}

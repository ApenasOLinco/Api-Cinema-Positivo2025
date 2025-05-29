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
public class GeneroController(GeneroService service) : ControllerBase
{
	private GeneroService GeneroService { get; } = service;

	[HttpGet]
	public ActionResult<List<GeneroGetDTO>> TodosOsGeneros()
	{
		var generos = GeneroService.TodosOsGeneros();

		return Ok(generos);
	}
}

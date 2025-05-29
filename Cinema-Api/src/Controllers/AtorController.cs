using Cinema_Api.src.Models.DTOs.Get;
using Cinema_Api.src.Models.DTOs.Post;
using Cinema_Api.src.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Api.src.Controllers;

public class AtorController(AtorService service) : ControllerBase
{
	private AtorService AtorService { get; } = service;

	[HttpPost]
	public ActionResult<AtorGetDTO> NovoAtor([FromBody] AtorPostDTO ator)
	{
		var atorCriado = AtorService.NovoAtor(ator);

		if (atorCriado is null)
		{
			return Conflict("O Ator já existe no banco de dados.");
		}

		// Trocar por Created(), vazio mesmo
		return Created();
	}

	[HttpDelete("{Id}")]
	public ActionResult<List<AtorGetDTO>> DeletarAtor(int Id)
	{
		AtorService.DeletarAtor(Id);

		return NoContent();
	}
}

using Cinema_Api.src.Models.DTOs.Filter;
using Cinema_Api.src.Models.DTOs.Get;
using Cinema_Api.src.Models.DTOs.HttpPatch;
using Cinema_Api.src.Models.DTOs.Post;
using Cinema_Api.src.Service;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior;

namespace Cinema_Api.src.Controllers;

public class DiretorController(DiretorService service) : ControllerBase
{
	private DiretorService DiretorService { get; } = service;

	[HttpPost]
	public ActionResult<DiretorGetDTO> NovoDiretor([FromBody] DiretorPostDTO diretor)
	{
		var diretorCriado = DiretorService.NovoDiretor(diretor);

		if (diretorCriado is null)
		{
			return Conflict("O Diretor já existe no banco de dados.");
		}

		// Trocar por Created(), vazio mesmo
		return Created();
	}



	[HttpGet]
	public ActionResult<List<DiretorGetDTO>> TodosOsDiretores()
	{
		var diretores = DiretorService.TodosOsDiretores();

		return Ok(diretores);
	}
}

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
public class DiretorController(DiretorService service) : ControllerBase
{
    private DiretorService DiretorService { get; } = service;

    [HttpDelete("{Id}")]

    public ActionResult<List<DiretorGetDTO>> DeletarDiretor(int Id)
    {
        DiretorService.DeletarDiretor(Id);

        return NoContent();
    }
    [HttpGet("{Id}")]
	public ActionResult<DiretorGetDTO> UmDiretor([FromRoute(Name = "id")] int Id)
	{
		var filme = DiretorService.UmDiretor(Id);

		return filme is null ? NotFound() : Ok(filme);
	}
    [HttpPost]
    public ActionResult<DiretorGetDTO> NovoDiretor([FromBody] DiretorPostDTO diretor)
    {
        var diretorCriado = DiretorService.NovoDiretor(diretor);

        if (diretorCriado is null)
        {
            return Conflict("O filme já existe no banco de dados.");
        }

        return CreatedAtAction(nameof(UmDiretor), new { id = diretorCriado.Id }, diretor);
    }
}

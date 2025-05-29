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
public class AtorController(AtorService service) : ControllerBase
{
    private AtorService AtorService { get; } = service;

    [HttpGet("{id}")]
    public ActionResult<DiretorGetDTO> UmAtor([FromRoute(Name = "Id")] int Id)
    {
        var ator = AtorService.UmAtor(Id);

        return ator is null ? NotFound() : Ok(ator);
    }
}

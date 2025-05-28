using Cinema_Api.src.Models.DTOs.Get;

namespace Cinema_Api.src.Models.DTOs;

public class Papel
{
	public required AtorGetDTO Ator { get; set; }

	public required string AtorPapel { get; set; }
}

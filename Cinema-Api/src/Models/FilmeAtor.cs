using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Api.src.Models;

[PrimaryKey("FilmeId", "AtorId")]
public class FilmeAtor
{
	public int FilmeId { get; set; }

	[JsonIgnore]
	public Filme Filme { get; set; } = null!;

	public int AtorId { get; set; }

	[JsonIgnore]
	public Ator Ator { get; set; } = null!;
}

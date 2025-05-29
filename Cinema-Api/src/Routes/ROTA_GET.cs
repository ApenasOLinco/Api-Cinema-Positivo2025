using Cinema_Api.src.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Api.src.Routes;

public class ROTA_GET
{
	private const string ROTA_BASE = "/api/v1";

	public static void MapGetRoutes(WebApplication app)
	{
		app.MapGet("/", () => Results.Redirect("/swagger"));

		MapearFilmes(app);
	}

	private static void MapearFilmes(WebApplication app)
	{
		const string ROTA_FILMES = "Filmes";

		// Todos os Filmes
		app.MapGet(
			$"{ROTA_BASE}/{ROTA_FILMES}",
			(FilmeService filmeService) =>
			{
				var filmes = filmeService.TodosOsFilmes();

				return Results.Ok(filmes);
			}
		);
	}
}

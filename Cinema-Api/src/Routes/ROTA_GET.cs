using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Api.src.Routes;

public class ROTA_GET
{
	public static void MapGetRoutes(WebApplication app)
	{
		app.MapGet("/", () => Results.Redirect("/swagger"));
	}
}

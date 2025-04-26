using Microsoft.AspNetCore.Mvc;
using portfolio_ms.Handlers.Interfaces;
using portfolio_ms.Models;

namespace portfolio_ms.Endpoints.Projects;

public class GetAllProjectsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
        => endpoints.MapGet("/", HandleAsync)
        .WithName("Projects: Get All")
        .WithDescription("Get all projects")
        .WithOrder(1)
        .Produces<List<Project>>();

    private static async Task<IResult> HandleAsync([FromServices] IProjectHandler projectHandler)
    {
        var result = await projectHandler.GetAllAsync();
        return TypedResults.Ok(result);
    }
}
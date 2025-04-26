using Microsoft.AspNetCore.Mvc;
using portfolio_ms.Handlers.Interfaces;
using portfolio_ms.Models;

namespace portfolio_ms.Endpoints.Projects;

public class GetProjectByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
        => endpoints.MapGet("/{id:guid}", HandleAsync)
            .WithName("Projects: Get by id")
            .WithDescription("Gets a project by id.")
            .WithOrder(2)
            .Produces<Project?>();

    private static async Task<IResult> HandleAsync([FromServices] IProjectHandler projectHandler, [FromRoute] Guid id)
    {
        var result = await projectHandler.GetByIdAsync(id);
        return result is not null 
            ? TypedResults.Ok(result)
            : TypedResults.NotFound();
    }
}
using Microsoft.AspNetCore.Mvc;
using portfolio_ms.DTOs;
using portfolio_ms.Handlers.Interfaces;
using portfolio_ms.Models;

namespace portfolio_ms.Endpoints.Projects;

public class CreateProjectEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
        => endpoints.MapPost("/", HandleAsync)
            .WithName("Projects: Create")
            .WithDescription("Creates a new project.")
            .WithOrder(3)
            .Produces<Project?>();

    private static async Task<IResult> HandleAsync(
        [FromServices] IProjectHandler projectHandler, 
        [FromBody] CreateProjectRequest request)
    {
        var project = new Project()
        {
            Name = request.Name,
            Description = request.Description,
            ImgUrl = request.ImgUrl,
            DeployUrl = request.DeployUrl,
            ProjectType = (ProjectType)request.ProjectType
        };
        
        var result = await projectHandler.CreateAsync(project);
        return result is not null
            ? TypedResults.Created($"/projects/{result.Id}", result)
            : TypedResults.BadRequest();
    }
}
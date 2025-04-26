using portfolio_ms.Endpoints.Projects;

namespace portfolio_ms.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { status = "ok" });

        endpoints.MapGroup("/projects")
            .WithTags("Projects")
            .MapEndpoint<GetProjectByIdEndpoint>()
            .MapEndpoint<CreateProjectEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder endpoints)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(endpoints);
        return endpoints;
    }
}
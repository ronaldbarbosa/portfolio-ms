namespace portfolio_ms.Endpoints;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder endpoints);
}
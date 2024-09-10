using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.User;

public class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => "Get endpoint");
    }
}
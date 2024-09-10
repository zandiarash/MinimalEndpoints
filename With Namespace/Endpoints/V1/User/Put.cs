using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.User;

public class Put : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("put", () => "Put endpoint");
    }
}
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.Category;

public class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => "Get endpoint");
        app.MapDelete("delete", () => "delete endpoint");
        app.MapPost("", () => "post endpoint");
        app.MapPut("", () => "put endpoint");
    }
}

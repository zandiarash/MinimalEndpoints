using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V2.Category;

public class CategoriesGet : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => "Get endpoint");
        app.MapDelete("delete", () => "delete endpoint");
        app.MapPost("", () => "post endpoint");
        app.MapPut("", () => "put endpoint");
    }
}

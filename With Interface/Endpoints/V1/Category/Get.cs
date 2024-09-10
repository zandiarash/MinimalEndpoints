using Asp.Versioning;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.Category;

public class Get : IEndpoint
{
    public string GroupName => "Category";
    public ApiVersion ApiVersion => new ApiVersion(1, 0); // Specify API version

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => "Get endpoint");
        app.MapDelete("delete", () => "delete endpoint");
        app.MapPost("", () => "post endpoint");
        app.MapPut("", () => "put endpoint");
    }
}

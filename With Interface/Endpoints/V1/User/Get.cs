using Asp.Versioning;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.User;

public class Get : IEndpoint
{
    public ApiVersion ApiVersion => new ApiVersion(1, 0); // Specify API version
    public string GroupName => "User";
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => "Get endpoint");
    }
}
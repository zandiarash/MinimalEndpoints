using Asp.Versioning;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.User;

public class Post : IEndpoint
{
    public ApiVersion ApiVersion => new ApiVersion(1, 0); // Specify API version
    public string GroupName => "Users";
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("post", () => "Post endpoint");
    }
}
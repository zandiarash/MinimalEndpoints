using Asp.Versioning;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.User;

public class Delete : IEndpoint
{
    public string GroupName => "User";
    public ApiVersion ApiVersion => new ApiVersion(1, 0); // Specify API version

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("delete", () => "Delete endpoint");
    }
}
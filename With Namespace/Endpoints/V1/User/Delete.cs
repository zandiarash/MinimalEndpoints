using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V1.User;

public class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("delete", () => "Delete endpoint");
    }
}
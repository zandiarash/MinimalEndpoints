using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V2.Category.SubCategory;

public class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => {
            return StatusCodes.Status201Created;
        });
    }
}

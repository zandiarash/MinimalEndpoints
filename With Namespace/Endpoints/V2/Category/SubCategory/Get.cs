using Asp.Versioning;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V2.Category.SubCategory;

public class CategoriesGet : IEndpoint
{
    public string GroupName => "Category";
    public ApiVersion ApiVersion => new ApiVersion(2, 0); // Specify API version

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => {
            return StatusCodes.Status201Created;
        });
    }
}

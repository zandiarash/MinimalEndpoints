﻿using Asp.Versioning;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Endpoints.V2.User;

public class CategoriesGet : IEndpoint
{
    public string GroupName => "Categories";
    public ApiVersion ApiVersion => new ApiVersion(2, 0); // Specify API version

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("get", () => "Get endpoint");
        app.MapDelete("delete", () => "delete endpoint");
        app.MapPost("", () => "post endpoint");
        app.MapPut("", () => "put endpoint");
    }
}

﻿using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IEndpointRouteBuilder MapEndpointWithTags(this RouteGroupBuilder builder, IEndpoint endpoint)
    {
        endpoint.MapEndpoint(builder);
        if (!string.IsNullOrEmpty(endpoint.TagName))
        {
            builder.WithTags(endpoint.TagName);
        }
        return builder;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (IEndpoint endpoint in endpoints)
        {
            if (endpoint is IEndpoint myEndpoint && myEndpoint.GroupName != null)
            {
                var endpointNamespace = endpoint.GetType().Namespace.Split(".");
                var version =  endpointNamespace[2].ToLower();
                var GroupNameForUrl =string.Join("/",endpointNamespace[3..]);
                var GroupNameForTagname =string.Join(".",endpointNamespace[3..]);

                // Use the API version from the endpoint
                var group = builder.MapGroup($"api/{version}/{GroupNameForUrl}")
                    // .WithApiVersionSet(endpoint.ApiVersion.ToString())
                    .WithTags($"{version}-{GroupNameForTagname}");

                // Map the endpoint to the group with versioning
                endpoint.MapEndpoint(group);
            }
        }

        return app;
    }

}

using MinimalEndpoints.Abstractions;

namespace MinimalEndpoints.Extensions;

public static class EndpointExtensions
{
    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        IEnumerable<IEndpoint> endpoints = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(IEndpoint).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(type => (IEndpoint)Activator.CreateInstance(type)!) // Create instances of those types
            .ToList();

        foreach (IEndpoint endpoint in endpoints)
        {
            var endpointNamespace = endpoint.GetType().Namespace?.Split(".");
            var version = endpointNamespace?[2];
            var GroupNameForUrl = string.Join("/", endpointNamespace[3..]);
            var GroupNameForTagName = string.Join(".", endpointNamespace[3..]);

            var group = app.MapGroup($"api/{version}/{GroupNameForUrl}".ToLower())
                .WithTags($"{version} {GroupNameForTagName}");

            endpoint.MapEndpoint(group);
        }

        return app;
    }

}

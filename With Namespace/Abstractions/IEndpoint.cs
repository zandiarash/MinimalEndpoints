using Asp.Versioning;

namespace MinimalEndpoints.Abstractions
{
    public interface IEndpoint
    {
        string GroupName { get; }
        string TagName => GroupName;
        ApiVersion ApiVersion { get; } // Add API version property

        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
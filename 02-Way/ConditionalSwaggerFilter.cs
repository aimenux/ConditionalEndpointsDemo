using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace _02_Way;

public sealed class ConditionalSwaggerFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        if (!Helpers.IsProduction()) return;

        foreach (var apiDescription in context.ApiDescriptions)
        {
            var relativePath = apiDescription.RelativePath;
            var attributes = apiDescription.ActionDescriptor.EndpointMetadata.OfType<ConditionalActionFilterAttribute>();
            if (!attributes.Any() || string.IsNullOrWhiteSpace(relativePath)) continue;
            var routes = swaggerDoc.Paths
                .Where(x => x.Key.Contains(relativePath, StringComparison.OrdinalIgnoreCase))
                .ToList();
            routes.ForEach(x => swaggerDoc.Paths.Remove(x.Key));
        }
    }
}
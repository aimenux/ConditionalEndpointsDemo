namespace _03_Way;

public class ConditionalMiddleware
{
    private readonly RequestDelegate _next;

    public ConditionalMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        if (IsEndpointToDisable(httpContext))
        {
            var endpoint = BuildDisabledEndpoint();
            httpContext.SetEndpoint(endpoint);
        }

        return _next(httpContext);
    }

    private static bool IsEndpointToDisable(HttpContext httpContext)
    {
        if (!Helpers.IsProduction()) return false;

        var isConditionalEndpoint = httpContext
            .GetEndpoint()?.Metadata
            .GetMetadata<ConditionalControllerAttribute>();

        return isConditionalEndpoint != null;
    }

    private static Endpoint BuildDisabledEndpoint()
    {
        static Task RequestDelegate(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return Task.CompletedTask;
        }

        return new Endpoint(RequestDelegate, EndpointMetadataCollection.Empty, "Endpoint is disabled");
    }
}
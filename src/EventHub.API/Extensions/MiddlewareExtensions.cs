namespace EventHub.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseApiExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<EventHub.Api.Middleware.ExceptionHandlingMiddleware>();
    }
}

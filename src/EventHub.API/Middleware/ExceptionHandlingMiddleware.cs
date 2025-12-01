using EventHub.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace EventHub.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception during request");

            context.Response.ContentType = "application/json";

            var (status, message) = ex switch
            {
                NotFoundException nf => (HttpStatusCode.NotFound, nf.Message),
                _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred")
            };

            context.Response.StatusCode = (int)status;

            var response = new
            {
                error = message,
                status = status.ToString()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

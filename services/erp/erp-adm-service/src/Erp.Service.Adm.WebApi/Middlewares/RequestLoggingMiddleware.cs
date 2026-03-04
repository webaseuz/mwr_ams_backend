namespace Erp.Service.Adm.WebApi;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log request details
        _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");

        await _next(context);

        // Optionally log response status
        _logger.LogInformation($"Response status: {context.Response.StatusCode}", context.Response.StatusCode);
    }
}

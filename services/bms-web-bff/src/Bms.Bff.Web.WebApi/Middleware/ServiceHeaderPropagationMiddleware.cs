using System.Security.Claims;

namespace Bms.Bff.Web.WebApi.Middleware;

/// <summary>
/// Middleware to propagate user context and headers to downstream services
/// </summary>
public class ServiceHeaderPropagationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ServiceHeaderPropagationMiddleware> _logger;

    public ServiceHeaderPropagationMiddleware(
        RequestDelegate next,
        ILogger<ServiceHeaderPropagationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Extract user information from the authenticated user
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                // Add user context headers for downstream services
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                    ?? context.User.FindFirst("sub")?.Value;
                var userName = context.User.FindFirst(ClaimTypes.Name)?.Value
                    ?? context.User.FindFirst("name")?.Value;
                var userEmail = context.User.FindFirst(ClaimTypes.Email)?.Value
                    ?? context.User.FindFirst("email")?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    context.Items["X-User-Id"] = userId;
                }

                if (!string.IsNullOrEmpty(userName))
                {
                    context.Items["X-User-Name"] = userName;
                }

                if (!string.IsNullOrEmpty(userEmail))
                {
                    context.Items["X-User-Email"] = userEmail;
                }

                // Extract and propagate custom claims
                var department = context.User.FindFirst("department")?.Value;
                if (!string.IsNullOrEmpty(department))
                {
                    context.Items["X-User-Department"] = department;
                }

                var permissions = context.User.FindAll("permission")
                    .Select(c => c.Value)
                    .ToList();
                if (permissions.Any())
                {
                    context.Items["X-User-Permissions"] = string.Join(",", permissions);
                }
            }

            // Propagate correlation ID for distributed tracing
            if (!context.Request.Headers.ContainsKey("X-Correlation-Id"))
            {
                var correlationId = Guid.NewGuid().ToString();
                context.Request.Headers.Add("X-Correlation-Id", correlationId);
                context.Items["X-Correlation-Id"] = correlationId;
            }
            else
            {
                context.Items["X-Correlation-Id"] = context.Request.Headers["X-Correlation-Id"].ToString();
            }

            // Propagate request language/culture
            var culture = context.Request.Headers["Accept-Language"].FirstOrDefault() 
                ?? Thread.CurrentThread.CurrentCulture.Name;
            context.Items["X-Request-Culture"] = culture;

            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in service header propagation middleware");
            throw;
        }
    }
}
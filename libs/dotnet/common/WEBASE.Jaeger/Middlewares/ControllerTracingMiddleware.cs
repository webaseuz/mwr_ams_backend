using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;

namespace WEBASE.Jaeger;

public class ControllerTracingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ControllerTracingMiddleware> _logger;
    private readonly Tracer _tracer;

    public ControllerTracingMiddleware(RequestDelegate next, ILogger<ControllerTracingMiddleware> logger, TracerProvider tracerProvider)
    {
        _next = next;
        _logger = logger;
        _tracer = tracerProvider.GetTracer(JaegerTraceConst.ANALYZER);
    }

    public async Task Invoke(HttpContext context)
    {
        var controllerName = context.GetRouteValue("controller")?.ToString();
        var actionName = context.GetRouteValue("action")?.ToString();
        var traceName = $"Controller: {controllerName} | Action: {actionName}";

        using (var activity = _tracer.StartActiveSpan(traceName, SpanKind.Server))
        {
            _logger.LogInformation($"Tracking controller scope: {controllerName}/{actionName}");
            activity.SetAttribute("controller", controllerName);
            activity.SetAttribute("action", actionName);
            activity.SetAttribute("http.method", context.Request.Method);
            activity.SetAttribute("http.url", context.Request.Path);

            try
            {
                await _next(context);

                activity.SetStatus(OpenTelemetry.Trace.Status.Ok);
            }
            catch (Exception ex)
            {
                activity.RecordException(ex);
                activity.SetStatus(OpenTelemetry.Trace.Status.Error);
                throw;
            }
        }
    }
}
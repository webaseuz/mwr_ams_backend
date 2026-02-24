using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;


namespace WEBASE.Jaeger;

public class MiddlewareTracingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ControllerTracingMiddleware> _logger;
    private readonly Tracer _tracer;

    public MiddlewareTracingMiddleware(RequestDelegate next, ILogger<ControllerTracingMiddleware> logger, TracerProvider tracerProvider)
    {
        _next = next;
        _logger = logger;
        _tracer = tracerProvider.GetTracer(JaegerTraceConst.ANALYZER);
    }

    public async Task Invoke(HttpContext context)
    {
        var traceName = $"Middlewares: app";

        using (var activity = _tracer.StartActiveSpan(traceName, SpanKind.Server))
        {
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

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WEBASE.LogSdk.BLL.Managers;
using WEBASE.LogSdk.Core.Extensions;
using WEBASE.Security.Abstraction;

namespace WEBASE.LogSdk.Core
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly AppErrorOptions _options;

        public ExceptionMiddleware(
            RequestDelegate next,
            AppErrorOptions options,
            ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _options = options;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IErrorManager errorManager, IBaseAuthService authService)
        {
            try
            {
                if (_options.IncludeBody)
                    httpContext.Request.EnableBuffering();

                await _next(httpContext);
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogWarning(ex, "BadHttpRequestException");
                await httpContext.HandleExceptionAsync(errorManager, authService, _options, _logger);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                await httpContext.HandleExceptionAsync(errorManager, authService, _options, _logger);
            }
        }
    }
}

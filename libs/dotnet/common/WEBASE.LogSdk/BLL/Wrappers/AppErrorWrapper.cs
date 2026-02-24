using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UAParser;
using WEBASE.LogSdk.BLL.Normalizers;
using WEBASE.LogSdk.Core.Extensions;
using WEBASE.LogSdk.Core.Helpers;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.Security.Abstraction;

namespace WEBASE.LogSdk.BLL.Wrappers;

public static class AppErrorWrapper
{
    /// <summary>
    /// Wraps an AppError into an ErrorScope.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="authService"></param>
    /// <param name="appErrorOptions"></param>
    /// <param name="exception"></param>
    /// <param name="detail"></param>
    /// <param name="statusCode"></param>
    /// <returns></returns>

    public static async Task<AppError> WrapAsync(HttpContext context,
                                                 IBaseAuthService authService,
                                                 AppErrorOptions appErrorOptions,
                                                 Exception exception,
                                                 string detail,
                                                 int statusCode)
    {
        // Create a new AppError object
        string requestBody = await RequestHelper.ReadRequestBodyAsync(context, appErrorOptions.IncludeBody);

        /// Normalize the request path
        var error = new AppError
        {
            HostName = context.Request.Host.Value,
            RequestPath = context.Request.Path,
            RequestBody = requestBody,
            StatusCode = statusCode,
            Type = exception.GetType()?.Name,
            Title = exception.Message.SubstringByLength(2000),
            RequestTraceId = context.TraceIdentifier,
            Detail = detail.SubstringByLength(appErrorOptions.DetailMaxLength),
            UserId = authService != null && await authService.IsAuthenticatedAsync() ? JsonConvert.SerializeObject(await authService.GetUserIdAsync()) : null,
            //UserName = authService != null && await authService.IsAuthenticatedAsync() ? await authService.GetUserIdAsync().Result.ToString() : null,
            //UserAgent = authService != null ? authService.use.SubstringByLength(2000) : null,
            //IpAddress = authService != null ? authService.UserIp : null
        };

        //
        var uaParser = Parser.GetDefault();
        if (uaParser != null && !string.IsNullOrEmpty(error.UserAgent))
        {
            var client = uaParser.Parse(error.UserAgent);

            error.UserAgentUA = client.UA.ToString();
            error.UserAgentOS = client.OS.ToString();
            error.UserAgentDevice = client.Device.ToString();
        }

        error.NormalizedRequestPath = RouteNormalizer.NormalizeURLPath(error.RequestPath);
        error.Code = ExceptionHasher.Generate(error.Title);

        return error;
    }
}

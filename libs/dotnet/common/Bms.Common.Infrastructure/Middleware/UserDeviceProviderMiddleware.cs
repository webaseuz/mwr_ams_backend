using Bms.WEBASE.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bms.WEBASE.Middleware;

public class UserDeviceProviderMiddleware
{
    private readonly RequestDelegate _next;

    public UserDeviceProviderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,
                                  IUserDeviceProvider deviceProvider)
    {
        if (context.Connection.RemoteIpAddress is not null)
        {
            var userIp = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                userIp = userIp + ";" + context.Request.Headers["X-Forwarded-For"];

            deviceProvider.SetUserIp(userIp);

            if (context.Request.Headers.ContainsKey("User-Agent"))
                deviceProvider.SetUserAgent(context.Request.Headers["User-Agent"]);
        }

        await _next(context);
    }
}

public static class UserDeviceMiddlewareExtension
{
    public static void UseUserDeviceMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<UserDeviceProviderMiddleware>();
}

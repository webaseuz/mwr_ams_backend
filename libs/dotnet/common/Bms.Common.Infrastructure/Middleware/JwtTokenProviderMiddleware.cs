using Bms.WEBASE.Extensions;
using Bms.WEBASE.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bms.WEBASE.Middleware;

public class JwtTokenProviderMiddleware
{
    private readonly RequestDelegate _next;
    protected virtual string AuthKey { get; set; } = "Authorization";

    public JwtTokenProviderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,
                                  ITokenProvider tokenProvider)
    {

        tokenProvider.SetToken(ReadTokenFromRequest(context));

        await _next(context);
    }

    private string ReadTokenFromRequest(HttpContext context)
    {
        string[] array = context.Request.Headers[AuthKey].FirstOrDefault().AsString().Split(' ');

        if (array.Length != 2 || array[0].AsString() != "Bearer")
            return null;

        return array[1].AsString();
    }
}

public static class JwtTokenMiddlewareExtension
{
    public static void UseJwtTokenMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<JwtTokenProviderMiddleware>();

}

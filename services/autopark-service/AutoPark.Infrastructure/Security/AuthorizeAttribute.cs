/*using AutoPark.Application;
using AutoPark.Application.Security;
using Bms.Common.Infrastructure;
using Bms.WEBASE.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoPark.Infrastructure;

public class AuthorizeAttribute :
    Attribute,
    IAsyncAuthorizationFilter
{
    private PermissionCode[] _permissions;

    public AuthorizeAttribute()
    { }

    public AuthorizeAttribute(params PermissionCode[] permissions)
        => _permissions = permissions;

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.Filters.Any(a => a is AllowAnonymousAttribute))
            return;

        var authService = (IAsyncAppAuthService)context.HttpContext
            .RequestServices
            .GetService(typeof(IAsyncAppAuthService));

        //Temporary solution for using without auth
        if (authService.AuthenticationType == nameof(AuthenticationTypeConst.NONE))
            return;

        var isAuthenticated = await authService.IsAuthenticatedAsync();

        if (authService == null || !isAuthenticated)
            context.Result = new UnauthorizedResult();
        else if (_permissions?.Any() == true)
        {
            foreach (var permission in _permissions)
                if (await authService.HasPermissionAsync(permission))
                    return;

            context.Result = new StatusCodeResult(403);
        }
    }
}
*/
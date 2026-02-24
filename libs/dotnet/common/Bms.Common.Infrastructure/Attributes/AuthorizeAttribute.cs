using Bms.WEBASE.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WEBASE.Security.Abstraction;

namespace Bms.Common.Infrastructure;

public class AuthorizeAttribute :
    Attribute,
    IAsyncAuthorizationFilter
{
    private string[] _permissions;

    public AuthorizeAttribute()
    { }

    public AuthorizeAttribute(params string[] permissions)
        => _permissions = permissions;

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.Filters.Any(a => a is AllowAnonymousAttribute))
            return;

        var authService = (IBaseAuthService)context.HttpContext
            .RequestServices
            .GetService(typeof(IBaseAuthService));

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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Erp.Adm.Bff.Web.Application;

namespace Erp.Adm.Bff.Web.WebApi;

public class AuthorizeFilter : Attribute, IAuthorizationFilter, IFilterMetadata
{
    //protected string[] PermissionCodes { get; }
    public AuthorizeFilter(
        //string[] permissionCodes
        )
    {
        //PermissionCodes = permissionCodes;
    }

    //public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //{
        //if (context.Filters.Any(a => a is AllowAnonymousAttribute))
        //    return;

        //var authServiceObj = context.HttpContext.RequestServices.GetService(typeof(IMainAuthService));
        //if (authServiceObj is null)
        //{
        //    throw new ArgumentNullException();
        //}

        //var authService = (IMainAuthService)authServiceObj;

        //if (!authService.IsAuthenticated)
        //{
        //    context.Result = new UnauthorizedResult();
        //}

        //if(PermissionCodes is not null && PermissionCodes.Any())
        //{
        //    // Check if the user has any of the required permissions
        //    var exist = await authService.HasAnyPermissionAsync(PermissionCodes);
        //    if (!exist)
        //    {
        //        context.Result = new StatusCodeResult(403);
        //    }
        //}
    //}

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.Filters.Any(a => a is AllowAnonymousAttribute))
            return;

        var authServiceObj = context.HttpContext.RequestServices.GetService(typeof(IMainAuthService));
        if (authServiceObj is null)
        {
            throw new ArgumentNullException();
        }

        var authService = (IMainAuthService)authServiceObj;

        if (!authService.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}

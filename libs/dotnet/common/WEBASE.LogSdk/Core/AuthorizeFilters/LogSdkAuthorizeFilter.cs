using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.AspNet.Security;
using WEBASE.Security.Abstraction;

namespace WEBASE.LogSdk.Core.AuthorizeFilters;

public class LogSdkAuthorizeFilter : Attribute, IAsyncAuthorizationFilter
{
    public string[] ModuleCodes { get; }

    public LogSdkAuthorizeFilter(string[] moduleCodes)
    {
        ModuleCodes = moduleCodes;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (!context.Filters.Any(f => f is AllowAnonymousAttribute))
        {
            var authService = (IBaseAuthService)context.HttpContext.RequestServices.GetRequiredService(typeof(IBaseAuthService));

            if (!await authService.IsAuthenticatedAsync())
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if ((ModuleCodes?.Any()).GetValueOrDefault())
            {
                var tasks = ModuleCodes!.Select(async code => await authService.HasPermissionAsync(code));
                var results = await Task.WhenAll(tasks);

                if (!results.Any(r => r))
                {
                    context.Result = new StatusCodeResult(403);
                }
            }
        }
    }
}
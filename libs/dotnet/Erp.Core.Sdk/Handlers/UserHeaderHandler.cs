using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WEBASE;

namespace Erp.Core.Sdk.Handlers;

public class UserHeaderHandler : DelegatingHandler
{
    private readonly IServiceProvider _serviceProvider;

    public UserHeaderHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();

        if (httpContextAccessor is not null && httpContextAccessor.HttpContext is not null)
        {
            var authService = httpContextAccessor.HttpContext.RequestServices.GetService<IWbAuthService>();
            // User header
            if (authService != null && !string.IsNullOrEmpty(authService.UserIdentityName))
            {
                request.Headers.Remove(ApplicationHeaderConst.User);
                request.Headers.TryAddWithoutValidation(ApplicationHeaderConst.User, authService.UserIdentityName);
            }
        }
        else
        {
            var authService = _serviceProvider.GetService<IWbAuthService>();
            // User header
            if (authService != null && !string.IsNullOrEmpty(authService.UserIdentityName))
            {
                request.Headers.Remove(ApplicationHeaderConst.User);
                request.Headers.Add(ApplicationHeaderConst.User, authService.UserIdentityName);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}

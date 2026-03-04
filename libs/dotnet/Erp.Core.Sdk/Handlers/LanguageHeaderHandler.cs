using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Core.Sdk;

/// <summary>
/// Handler to propagate language headers to service API requests
/// </summary>
public class LanguageHeaderHandler : DelegatingHandler
{
    private readonly IServiceProvider _serviceProvider;

    public LanguageHeaderHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
        var httpContext = httpContextAccessor?.HttpContext;

        if (httpContext != null)
        {
            // Add language header from the current request
            if (httpContext.Request.Headers.TryGetValue(ApplicationHeaderConst.Language, out var langHeader))
            {
                // Ensure no duplicate headers
                if (request.Headers.Contains(ApplicationHeaderConst.Language))
                {
                    request.Headers.Remove(ApplicationHeaderConst.Language);
                }
                request.Headers.Add(ApplicationHeaderConst.Language, langHeader.ToString());
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Bms.Bff.Web.WebApi.Security;

/// <summary>
/// Factory for selecting the appropriate token handler based on configuration
/// </summary>
public class TokenHandlerFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AppSettings _appSettings;

    public TokenHandlerFactory(IServiceProvider serviceProvider, AppSettings appSettings)
    {
        _serviceProvider = serviceProvider;
        _appSettings = appSettings;
    }

    public ITokenHandler GetHandler(string providerName = null)
    {
        // Use default provider if not specified
        providerName ??= _appSettings.Authentication.DefaultProvider;

        // Get the provider configuration
        var providerConfig = _appSettings.Authentication.Providers
            .FirstOrDefault(p => p.Name == providerName && p.Enabled);

        if (providerConfig == null)
        {
            throw new InvalidOperationException($"Authentication provider '{providerName}' is not configured or disabled");
        }

        // Return the appropriate handler based on type
        return providerConfig.Type switch
        {
            "BmsJwtProvider" => _serviceProvider.GetRequiredService<BmsJwtTokenHandler>(),
            "BmsReferenceProvider" => _serviceProvider.GetRequiredService<BmsReferenceTokenHandler>(),
            _ => throw new NotSupportedException($"Token provider type '{providerConfig.Type}' is not supported")
        };
    }

    public IEnumerable<ITokenHandler> GetAllEnabledHandlers()
    {
        var enabledProviders = _appSettings.Authentication.Providers
            .Where(p => p.Enabled)
            .ToList();

        foreach (var provider in enabledProviders)
        {
            ITokenHandler handler = provider.Type switch
            {
                "BmsJwtProvider" => _serviceProvider.GetRequiredService<BmsJwtTokenHandler>(),
                "BmsReferenceProvider" => _serviceProvider.GetRequiredService<BmsReferenceTokenHandler>(),
                _ => null
            };

            if (handler != null)
            {
                yield return handler;
            }
        }
    }
}
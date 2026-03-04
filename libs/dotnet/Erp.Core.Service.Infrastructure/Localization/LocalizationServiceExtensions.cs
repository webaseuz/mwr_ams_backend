using Erp.Core.Service.Application.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Core.Service.Infrastructure.Localization;

/// <summary>
/// Dependency injection extensions for LocalizationService
/// </summary>
public static class LocalizationServiceExtensions
{
    /// <summary>
    /// Registers LocalizationService with Google Sheets support (CSV or Excel)
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">Configuration</param>
    /// <returns>Service collection</returns>
    public static IServiceCollection AddLocalizationService(
        this IServiceCollection services/*,
        IConfiguration configuration*/)
    {
        // Register configuration from appsettings.json
        /*services.Configure<LocalizationOptions>(
            configuration.GetSection("Localization"));*/

        services.Configure<LocalizationOptions>(options => new LocalizationOptions
        {
            AutoRefreshIntervalMinutes = 24 * 60,
            CacheDurationMinutes = 60 * 60,
            EnableAutoRefresh = true,
            GoogleSheetsFormat = "excel",
            GoogleSheetsUrl = "https://docs.google.com/spreadsheets/d/1mLfkUU3Ud3Or2InZk6gGKU4GaRPFhgTN6PuRfdNySJ8/edit?gid=0#gid=0"
        });

        // Register HttpClient for Google Sheets
        services.AddHttpClient();

        // Register memory cache if not already registered
        services.AddMemoryCache();

        // Register the service as Scoped (not Singleton) because it depends on ICultureHelper which is Scoped
        services.AddScoped<ILocalizationService, LocalizationService>();

        // Register the fluent builder
        services.AddScoped<ILocalizationBuilder, LocalizationBuilder>();

        return services;
    }
}

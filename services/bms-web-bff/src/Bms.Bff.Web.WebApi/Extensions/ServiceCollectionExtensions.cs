using Bms.Bff.Web.Infrastructure.HttpClients;
using Bms.Bff.Web.WebApi.Security;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace Bms.Bff.Web.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add flexible authentication that preserves YOUR superior implementation
    /// </summary>
    public static IServiceCollection AddFlexibleAuthentication(this IServiceCollection services, AppSettings appSettings)
    {
        // Register token handlers
        services.AddScoped<BmsJwtTokenHandler>();
        services.AddScoped<BmsReferenceTokenHandler>();
        services.AddScoped<TokenHandlerFactory>();

        // Configure authentication based on settings
        var defaultProvider = appSettings.Authentication.DefaultProvider;
        var providerConfig = appSettings.Authentication.Providers
            .FirstOrDefault(p => p.Name == defaultProvider && p.Enabled);

        if (providerConfig != null)
        {
            // Configure based on provider type
            switch (providerConfig.Type)
            {
                case "BmsJwtProvider":
                    // YOUR superior JWT is already configured in AddInfrastructure()
                    // This just adds the flexible wrapper on top
                    break;
                    
                case "BmsReferenceProvider":
                    // YOUR superior reference token is already configured
                    // This just adds the flexible wrapper on top
                    break;
                    
                default:
                    throw new NotSupportedException($"Authentication provider type '{providerConfig.Type}' is not supported");
            }
        }

        return services;
    }

    /// <summary>
    /// Add service clients with Refit
    /// </summary>
    public static IServiceCollection AddServiceClients(this IServiceCollection services, AppSettings appSettings)
    {
        // Configure HttpClient for AutoPark service
        services.AddRefitClient<IAutoParkServiceApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(appSettings.Services.AutoParkService.BaseUrl);
                c.Timeout = TimeSpan.FromSeconds(appSettings.Services.AutoParkService.Timeout);
            })
            .AddPolicyHandler(GetRetryPolicy(appSettings.Services.AutoParkService.RetryPolicy))
            .AddPolicyHandler(GetCircuitBreakerPolicy());

        // Configure HttpClient for ServiceDesk service
        services.AddRefitClient<IServiceDeskServiceApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(appSettings.Services.ServiceDeskService.BaseUrl);
                c.Timeout = TimeSpan.FromSeconds(appSettings.Services.ServiceDeskService.Timeout);
            })
            .AddPolicyHandler(GetRetryPolicy(appSettings.Services.ServiceDeskService.RetryPolicy))
            .AddPolicyHandler(GetCircuitBreakerPolicy());

        // Add additional services dynamically
        foreach (var (serviceName, serviceConfig) in appSettings.Services.AdditionalServices ?? new())
        {
            // This would need reflection or a factory pattern for dynamic service registration
            // For now, it's a placeholder for future services
        }

        return services;
    }

    /// <summary>
    /// Add BMS health checks
    /// </summary>
    public static IServiceCollection AddBmsHealthChecks(this IServiceCollection services, AppSettings appSettings)
    {
        var healthChecksBuilder = services.AddHealthChecks()
            // Check downstream services
            .AddTypeActivatedCheck<ServiceHealthCheck>(
                name: "autopark-service",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "service", "autopark" },
                args: new object[] { appSettings.Services.AutoParkService })
            
            .AddTypeActivatedCheck<ServiceHealthCheck>(
                name: "servicedesk-service",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "service", "servicedesk" },
                args: new object[] { appSettings.Services.ServiceDeskService })
            
            // BFF-specific health check
            .AddCheck("bff-business-logic", () =>
            {
                return HealthCheckResult.Healthy("BFF service is operational");
            }, tags: new[] { "business", "bff" });

        // Add health check UI for development/staging
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        if (environment != "Production")
        {
            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(appSettings.HealthChecks.CheckInterval);
                options.MaximumHistoryEntriesPerEndpoint(50);
                
                // Add endpoints for all services
                options.AddHealthCheckEndpoint("BFF Service", "/health");
                foreach (var service in appSettings.HealthChecks.Services)
                {
                    options.AddHealthCheckEndpoint(service.Name, service.Url);
                }
            }).AddInMemoryStorage();
        }

        return services;
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(RetryPolicyConfig config)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(
                retryCount: config.RetryCount,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(config.BackoffMultiplier, retryAttempt)),
                onRetry: (outcome, timespan, retryCount, context) =>
                {
                    var logger = context.Values.ContainsKey("ILogger") ? context.Values["ILogger"] as ILogger : null;
                    logger?.LogWarning("Retry {RetryCount} after {Timespan}s", retryCount, timespan.TotalSeconds);
                });
    }

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 5,
                durationOfBreak: TimeSpan.FromSeconds(30));
    }
}

// Custom health check for downstream services
public class ServiceHealthCheck : IHealthCheck
{
    private readonly ServiceEndpointConfig _serviceConfig;
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceHealthCheck(ServiceEndpointConfig serviceConfig, IHttpClientFactory httpClientFactory)
    {
        _serviceConfig = serviceConfig;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_serviceConfig.BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            var response = await httpClient.GetAsync(_serviceConfig.HealthEndpoint, cancellationToken);
            
            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy($"Service at {_serviceConfig.BaseUrl} is healthy");
            }

            return HealthCheckResult.Unhealthy($"Service at {_serviceConfig.BaseUrl} returned {response.StatusCode}");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(
                description: $"Service at {_serviceConfig.BaseUrl} health check failed",
                exception: ex);
        }
    }
}
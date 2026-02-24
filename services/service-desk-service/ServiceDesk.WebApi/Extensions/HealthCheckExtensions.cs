/*using Bms.WEBASE.MinioSdk;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ServiceDesk.Infrastructure.Context;

namespace ServiceDesk.WebApi.Extensions;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddBmsHealthChecks(this IServiceCollection services, AppSettings appSettings)
    {
        var healthChecksBuilder = services.AddHealthChecks()
            // Database health check
            .AddDbContextCheck<ServiceDeskDbContext>(
                name: "servicedesk-database",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "database", "sql", "servicedesk" })
            
            // MinIO storage health check
            .AddTypeActivatedCheck<MinioHealthCheck>(
                name: "minio-storage",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "storage", "minio" },
                args: new object[] { appSettings.Minio })
            
            // Custom business logic health check
            .AddCheck("servicedesk-business-logic", () =>
            {
                // Add any custom business logic checks here
                // For example: check if ticket processing is available
                return HealthCheckResult.Healthy("ServiceDesk service is operational");
            }, tags: new[] { "business", "servicedesk" });

        // Add health check UI for development/staging environments
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        if (environment != "Production")
        {
            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(30); // Check every 30 seconds
                options.MaximumHistoryEntriesPerEndpoint(50);
                options.AddHealthCheckEndpoint("ServiceDesk Service", "/health");
            }).AddInMemoryStorage();
        }

        return services;
    }
}

// Custom health check for MinIO
public class MinioHealthCheck : IHealthCheck
{
    private readonly MinioConfig _minioConfig;

    public MinioHealthCheck(MinioConfig minioConfig)
    {
        _minioConfig = minioConfig;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Here you would check MinIO connectivity
            // For now, we'll return healthy if config exists
            if (string.IsNullOrEmpty(_minioConfig?.Endpoint))
            {
                return HealthCheckResult.Unhealthy("MinIO configuration is missing");
            }

            // TODO: Add actual MinIO connectivity check
            return HealthCheckResult.Healthy("MinIO storage is accessible");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(
                description: "MinIO storage check failed",
                exception: ex);
        }
    }
}*/
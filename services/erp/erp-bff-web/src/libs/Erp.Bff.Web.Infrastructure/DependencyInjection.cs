using Microsoft.Extensions.DependencyInjection;

namespace Erp.Adm.Bff.Web.Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureWebBffInfrastructure(this IServiceCollection services)
    {
        services.ConfigureSdks();
    }
}

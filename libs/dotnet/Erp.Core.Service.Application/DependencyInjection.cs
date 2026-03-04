using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Core.Service.Application;

public static class DependencyInjection
{
    public static void ConfigureServiceApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}


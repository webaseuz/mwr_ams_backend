using System.Reflection;
using Erp.Core.Models;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Application.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Service.Adm.Application;

public static class DependencyInjection
{
    public static void ConfigureAdmApplication(this IServiceCollection services)
    {
        services.ConfigureServiceApplication();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        // Password validation services
        services.AddScoped<IPasswordValidationService, PasswordValidationService>();
        services.RegisterAllRowChangeLogHandlers();

       /* services.RegisterRowChangeLogHandler<int, PersonFullDto>();
        services.RegisterRowChangeLogHandler<int, PersonDto>();*/
    }
}

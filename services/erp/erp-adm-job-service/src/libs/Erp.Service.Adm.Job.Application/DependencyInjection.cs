using System.Reflection;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Job.Application.Services.JobRunners;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Service.Adm.Job.Application;

public static class DependencyInjection
{
    public static void ConfigureAdmJobApplication(this IServiceCollection services)
    {
        services.ConfigureServiceApplication();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        services.AddCustomJobRunner();
    }
}

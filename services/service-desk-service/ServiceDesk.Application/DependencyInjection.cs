using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;
using ServiceDesk.Application.UseCases.NotificationServices;

namespace ServiceDesk.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IMapProvider, MapProvider>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped<IDocumentHistoryService, DocumentHistoryService>();
        services.AddScoped<ISpareTurnoverService, SpareTurnoverService>();
        services.AddScoped<INotificationService, NotificationService>();

        return services;
    }
}

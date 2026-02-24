using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Application.UseCases.NotificationServices;
using AutoPark.Application.UseCases.RelationServices;
using AutoPark.Application.UseCases.Services.OptimalRouteService;
using AutoPark.Integration.Service.MapService.Concrete;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutoPark.Application;

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
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IEntityRelationService, EntityRelationService>();
        services.AddScoped<IOptimalRouteService, OptimalRouteService>();
        services.AddScoped<IExternalOptimalRouteService, ExternalOptimalRouteService>();

        return services;
    }
}

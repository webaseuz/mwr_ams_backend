using AutoPark.Application;
using AutoPark.Infrastructure;
using AutoPark.MobileApi;
using AutoPark.MobileApi.Extensions;
using Bms.Core.Application;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Constants;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json.Converters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AlterEnvironmentConfiguration();
AppSettings.Init(builder.Configuration.Get<AppSettings>());

builder.Services.ConfigureConfigs();
builder.Services.ConfigureDbServices(AppSettings.Instance.Database);

builder.Services.AddInfrastructure();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddApplication();
builder.Services.AddMinioCLient(AppSettings.Instance.Minio);
builder.Services.AddMinioCLient(AppSettings.Instance.Minio);
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddSignalR();
builder.Services.AddIntagration(AppSettings.Instance.Integration.AutoParkHttpConfig);


builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerServices(AppSettings.Instance.Swagger);

builder.WebHost.ConfigureKestrel((context, oprtions) =>
{
    oprtions.ListenAnyIP(AppSettings.Instance.KestrelCustom.Endpoints.Http1.Port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
});

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter { AllowIntegerValues = false });
    options.SerializerSettings.Converters.Add(new TrimmingStringConverter());
    options.SerializerSettings.Converters.Add(new WbDateTimeConverter());
    options.SerializerSettings.Converters.Add(new WbDateConverter());
    options.SerializerSettings.DateFormatString = WbConstants.DATE_FORMAT;
});

var app = builder.Build();

BaseServiceProvider.Initialize(() => app.Services.GetService<IHttpContextAccessor>().HttpContext.RequestServices);


app.UseConfiguredSwagger(AppSettings.Instance.Swagger);

app.UseConfiguredExceptionHandling(AppSettings.Instance.ClientErrors);

app.UseUserDeviceMiddleware();
app.UseJwtTokenMiddleware();
//app.UseCors();


app.UseAuthorization();
app.UseAuthentication();

app.MapHub<TrackingInfoHub>("/trackingInfoHub");

app.MapControllers();

app.Run();

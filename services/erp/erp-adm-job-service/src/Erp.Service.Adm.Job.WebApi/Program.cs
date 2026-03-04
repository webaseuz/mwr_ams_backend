using Erp.Core;
using Erp.Service.Adm.Job.Application;
using Erp.Service.Adm.Job.Infrastructure;
using Erp.Service.Adm.Job.WebApi;
using WEBASE.AppError.Abstraction;
using WEBASE.AppError.AspNet;
using WEBASE.AppError.PostgreSQL;
using WEBASE.AspNet;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AlterEnvironmentConfiguration();
AppSettings.Init(builder.Configuration.Get<AppSettings>());

// ASP.NET Features
builder.Services.AddControllers(options =>
{
    options.Filters.Add<WbClientExceptionFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new
        Erp.Core.Extensions.CustomDateTimeConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();

// Layer Configurations
builder.Services.ConfigureAdmJobApplication();
builder.Services.ConfigureAdmJobInfrastructure(builder.Configuration);
builder.Services.ConfigureAdmJobWebApi();

builder.Services
    .AddAppError(AppSettings.Instance.AppError)
    .WithPostgreSql()
    .WithAspNet();

builder.Services.ConfigureAuthServices();

var app = builder.Build();

app.UseHealthChecks("/AdmJobServiceHealth");
app.UseServiceSwagger();
app.UseHttpsRedirection();
app.UseAppError();
app.UseAuthorization();
app.MapControllers();
app.Run();

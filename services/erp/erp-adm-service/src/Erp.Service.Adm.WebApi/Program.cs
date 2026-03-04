using Erp.Core;
using Erp.Service.Adm.Application;
using Erp.Service.Adm.Infrastructure;
using Erp.Service.Adm.WebApi;
using WEBASE.AppError.Abstraction;
using WEBASE.AppError.AspNet;
using WEBASE.AppError.PostgreSQL;
using WEBASE.AspNet;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AlterEnvironmentConfiguration();
AppSettings.Init(builder.Configuration.Get<AppSettings>());

//builder.Services.ConfigureConfigs();

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
builder.Services.ConfigureAdmApplication();
builder.Services.ConfigureAdmInfrastructure(builder.Configuration);
builder.Services.ConfigureAdmWebApi();

builder.Services
    .AddAppError(AppSettings.Instance.AppError)
    .WithPostgreSql()
    .WithAspNet();

builder.Services.ConfigureAuthServices();

var app = builder.Build();

app.UseHealthChecks("/AdmServiceHealth");
app.UseServiceSwagger();
app.UseHttpsRedirection();
app.UseAppError();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

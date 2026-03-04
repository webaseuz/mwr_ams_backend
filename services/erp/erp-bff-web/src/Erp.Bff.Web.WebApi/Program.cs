using Erp.Adm.Bff.Web.Application;
using Erp.Adm.Bff.Web.Infrastructure;
using Erp.Adm.Bff.Web.WebApi;
using Erp.Core;
using WEBASE.AspNet;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AlterEnvironmentConfiguration();
AppSettings.Init(builder.Configuration.Get<AppSettings>());

// ASP.NET Features
builder.Services.AddControllers(options =>
{
    options.Filters.Add<WbClientExceptionFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new 
        Erp.Core.Extensions.CustomDateTimeConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCorsServices();

// Layer Configurations
builder.Services.ConfigureWebBffApplication();
builder.Services.ConfigureWebBffInfrastructure();
builder.Services.ConfigureWebBffWebApi();



var app = builder.Build();

app.ConfigureCors();

app.UseHealthChecks("/AdmWebBffHealth");
app.UseBffSwagger();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

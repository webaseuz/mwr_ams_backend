using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Erp.Core;

namespace Erp.Service.Adm.WebApi;

public static class SwaggerServiceExtentions
{
    public static IServiceCollection AddServiceSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<UserHeaderFilter>();
            options.OperationFilter<LanguageHeaderFilter>();
        });

        return services;
    }

    // Custom Operation Filter to enforce the X-User header
    public class UserHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = ApplicationHeaderConst.User,
                In = ParameterLocation.Header,
                Required = false, // Make it required if needed
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                },
                Description = "User Identifier"
            });
        }
    }

    // Custom Operation Filter to enforce the X-Tenant header
    public class LanguageHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = ApplicationHeaderConst.Language,
                In = ParameterLocation.Header,
                Required = false, // Make it required if needed
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString(AppSettings.Instance.Culture.DefaultCulture)
                },
                Description = "Language Code"
            });
        }
    }

    public static WebApplication UseServiceSwagger(this WebApplication app)
    {
        if (AppSettings.Instance.Swagger.Enabled)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}



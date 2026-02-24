using Bms.WEBASE.Config;
using Bms.WEBASE.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.Extensions.DependencyInjection;
public static class SwaggerExtentions
{
    public static void UseConfiguredSwagger(
        this IApplicationBuilder app,
        SwaggerConfig config)
    {
        if (config.Enabled)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"../swagger/{config.Version}/swagger.json", config.Title);
                c.DocExpansion(DocExpansion.None);
            });
        }
    }

    public static void ConfigureSwaggerServices(
        this IServiceCollection services,
        SwaggerConfig config)
    {
        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(x => x.FullName);

            c.SwaggerDoc(config.Version,
                new OpenApiInfo
                {
                    Title = config.Title,
                    Version = "v1",
                });

            c.AddSecurityDefinition("Bearer",
                   new OpenApiSecurityScheme
                   {
                       Description = @"JWT Authorization header using the Bearer scheme. <br />
                                    Enter 'Bearer' [space] and then your token in the text input below. <br /><br />
                                    Example: 'Bearer 12345abcdef'",
                       Name = "Authorization",
                       In = ParameterLocation.Header,
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer",
                   });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });

            c.SchemaFilter<SwaggerExcludeFilter>();
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            c.MapType<DateTime>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
            });


#if !DEBUG
            /*if (!string.IsNullOrEmpty(prefex))
                c.DocumentFilter<PathPrefixInsertDocumentFilter>(prefex);*/
#endif

        });

        services.AddSwaggerGenNewtonsoftSupport();
    }
}

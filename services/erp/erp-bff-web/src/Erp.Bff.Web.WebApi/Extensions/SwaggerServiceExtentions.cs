using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Erp.Core;

namespace Erp.Adm.Bff.Web.WebApi;

public static class SwaggerServiceExtentions
{
    public static IServiceCollection ConfigureWebBffSwagger(this IServiceCollection services)
    {
        var conf = AppSettings.Instance.Idp;

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{conf.BaseUrl}/realms/{conf.Realm}/protocol/openid-connect/auth"),
                        TokenUrl = new Uri($"{conf.BaseUrl}/realms/{conf.Realm}/protocol/openid-connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { "openid", "OpenID Connect scope" },
                            { "profile", "Access user's profile information" },
                        }
                    }
                }
            });

            // Apply security to all endpoints
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Keycloak",
                            Type = ReferenceType.SecurityScheme
                        },
                        In=ParameterLocation.Header,
                        Scheme = "Bearer"
                    },
                    new List<string> {"openid", "profile" }
                }
            });

            options.OperationFilter<LanguageHeaderFilter>();

            if (!string.IsNullOrEmpty(AppSettings.Instance.Swagger.Prefix))
                options.DocumentFilter<PathPrefixInsertDocumentFilter>(AppSettings.Instance.Swagger.Prefix);

        });

        return services;
    }

    // Custom Operation Filter to enforce the X-Tenant header
    public static void UseBffSwagger(this IApplicationBuilder app)
    {
        if (AppSettings.Instance.Swagger.Enabled)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId(AppSettings.Instance.Swagger.IdpClientId);
                c.OAuthScopes("openid", "profile");
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.OAuthUsePkce();

                c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>
                {
                    { "prompt", "login" }
                });
            });
        }
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

public class PathPrefixInsertDocumentFilter : IDocumentFilter
{
    private readonly string _pathPrefix;

    public PathPrefixInsertDocumentFilter(string prefix)
    {
        this._pathPrefix = prefix;
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths.Keys.ToList();
        foreach (var path in paths)
        {
            var pathToChange = swaggerDoc.Paths[path];
            swaggerDoc.Paths.Remove(path);
            swaggerDoc.Paths.Add($"/{_pathPrefix}{path}", pathToChange);
        }
    }
}

public static class CorsServiceExtentions
{
    public static void ConfigureCorsServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            options.AddPolicy("AllowedOrgins",
            builder =>
            {
                if (AppSettings.Instance.Cors.UseCors)
                    builder
                    .WithOrigins(AppSettings.Instance.Cors.AllowedOrgins.Split(new string[] { ",", ";" }, StringSplitOptions.None))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                else
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    /*.AllowCredentials()*/;
            });
        });
    }
}


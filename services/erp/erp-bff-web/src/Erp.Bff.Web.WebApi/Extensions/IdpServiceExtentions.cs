using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Erp.Adm.Bff.Web.WebApi;

namespace Erp.Adm.Bff.Web.WebApi;

public static class IdpServiceExtentions
{
    public static IServiceCollection ConfigureWebBffAuthentication(this IServiceCollection services)
    {
        var config = AppSettings.Instance.Idp;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.MetadataAddress = $"{config.BaseUrl}/realms/{config.Realm}/.well-known/openid-configuration";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidIssuer = $"{config.BaseUrl}/realms/{config.Realm}",
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
                options.RequireHttpsMetadata = false;
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        // Access the validated token and claims
                        var jwtToken = context.SecurityToken as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;
                        var claims = context.Principal.Claims;

                        // Validate authorized partyClaim
                        //var authorizedPartyClaim = claims.FirstOrDefault(c => c.Type == "azp");
                        //if (authorizedPartyClaim != null)
                        //{
                        //    if (authorizedPartyClaim.Value != config.ClientId)
                        //    {
                        //        string party = authorizedPartyClaim.Value;
                        //        party = party.Replace("-swagger", "-api");
                        //        party = party.Replace("-web", "-api");

                        //        if (party.ToLower() != config.ClientId.ToLower())
                        //        {
                        //            context.Fail($"Custom claim validation failed. Field: azp");
                        //            return Task.CompletedTask;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    context.Fail($"Custom claim validation failed. Field: azp");
                        //    return Task.CompletedTask;
                        //}

                        // Add more custom validation logic here
                        return Task.CompletedTask;
                    }
                };
            });

        return services;
    }
}


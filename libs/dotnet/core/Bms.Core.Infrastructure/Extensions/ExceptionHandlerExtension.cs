using Bms.Core.Domain;
using Bms.WEBASE.Config;
using Bms.WEBASE.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bms.Core.Infrastructure;


public static class ExceptionHandlerExtension
{
    public static void UseConfiguredExceptionHandling(
        this IApplicationBuilder app,
        ClientErrorsConfig errorConfig)
    {
        if (errorConfig.ContentType.NullOrWhiteSpace())
            errorConfig.ContentType = "application/json";

        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                context.Response.ContentType = errorConfig.ContentType;

                var error = context.Features.Get<IExceptionHandlerFeature>();

                if (error != null && errorConfig.Enabled)
                {
                    var ex = error.Error.GetInnermostException();

                    var problem = new Error();

                    if (ex is BaseException baseException)
                        problem.ParseFrom(baseException, context.TraceIdentifier);
                    else
                        problem.ParseUnknownFrom(ex, context.TraceIdentifier, error.Error.GetType().Name);

                    if (problem.Type == ErrorType.SERVER)
                        context.Response.StatusCode = 500;
                    else
                        context.Response.StatusCode = 400;

                    string json = JsonConvert.SerializeObject(problem,
                                                              new StringEnumConverter { AllowIntegerValues = false });

                    await context.Response.WriteAsync(json);
                }
            });
        });
    }
}

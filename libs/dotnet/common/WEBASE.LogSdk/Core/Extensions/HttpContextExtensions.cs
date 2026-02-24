using Bms.Core.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using WEBASE.LogSdk.BLL.Managers;
using WEBASE.LogSdk.BLL.Wrappers;
using WEBASE.Security.Abstraction;

namespace WEBASE.LogSdk.Core.Extensions;

public static class HttpContextExtensions
{
    public static async Task HandleExceptionAsync(this HttpContext context,
                                                  IErrorManager errorManager,
                                                  IBaseAuthService authService,
                                                  AppErrorOptions appErrorOptions,
                                                  ILogger logger)
    {
        try
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (exceptionHandlerFeature!.Error is BadHttpRequestException)
                statusCode = ((BadHttpRequestException)exceptionHandlerFeature.Error).StatusCode;

            var problem = new Error();

            if (exceptionHandlerFeature != null)
            {
                var exception = exceptionHandlerFeature.Error.GetInnermostException();
                var detail = $"StackTrace: {Environment.NewLine}{exception.StackTrace}{Environment.NewLine} Full exception: {Environment.NewLine}{exceptionHandlerFeature.Error}";

                if (appErrorOptions.Enabled)
                    await context.WriteErrorToDb(authService, errorManager, appErrorOptions, exception, detail, statusCode, logger);

                problem.ExceptionName = exception.Message;
                problem.Message = appErrorOptions.IncludeDetailInResponse ? detail : null;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                if (exception is BaseException baseException)
                    problem.ParseFrom(baseException, context.TraceIdentifier);
                else
                    problem.ParseUnknownFrom(exception, context.TraceIdentifier, exceptionHandlerFeature.Error.GetType().Name);

                if (problem.Type == ErrorType.SERVER)
                    context.Response.StatusCode = 500;
                else
                    context.Response.StatusCode = 400;

                string json = JsonConvert.SerializeObject(problem,
                                                          new StringEnumConverter { AllowIntegerValues = false });

                await context.Response.WriteAsync(json);
            }


            // await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(problem));
        }
        catch (Exception ex)
        {
            if (logger != null)
                logger.LogCritical(ex, "An error occurred while handling exception in CUSTOM_MIDDLEWARE.");
        }
    }

    internal static async Task WriteErrorToDb(this HttpContext context,
                                                 IBaseAuthService authService,
                                                 IErrorManager errorManager,
                                                 AppErrorOptions appErrorOptions,
                                                 Exception exception,
                                                 string detail,
                                                 int statusCode,
                                                 ILogger logger)
    {
        try
        {
            var error = await AppErrorWrapper.WrapAsync(context, authService, appErrorOptions, exception, detail, statusCode);

            // write to db
            await errorManager.ErrorOccuredAsync(error);
        }
        catch (Exception ex)
        {
            if (logger != null)
                logger.LogInformation(ex, "An error occurred while handling exception in CUSTOM_MIDDLEWARE.");
        }
    }
}

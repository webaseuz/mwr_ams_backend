using Newtonsoft.Json;
using WEBASE;

public class ApiErrorHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        // Check if the response indicates an error
        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorResponseAsync(response);
        }

        return response;
    }

    private async Task HandleErrorResponseAsync(HttpResponseMessage response)
    {
        // Handle 401 Unauthorized
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new WbClientException()
                .WithSeverity(WbExceptionSeverity.HIGH)
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "UNAUTHORIZED",
                    ErrorMessage = "Autentifikatsiya muvaffaqiyatsiz tugadi. Iltimos, ma'lumotlaringizni tekshiring va qayta urinib ko'ring."
                });
        }

        // Handle 403 Forbidden
        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            throw new WbClientException()
                .WithSeverity(WbExceptionSeverity.HIGH)
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "FORBIDDEN",
                    ErrorMessage = "Kirish rad etildi. Sizda ushbu resursga kirish huquqi yo'q."
                });
        }

        var content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
        {
            throw new WbClientException()
                .WithSeverity(WbExceptionSeverity.MEDIUM)
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "EXTERNAL_SERVICE_ERROR",
                    ErrorMessage = "Tashqi xizmat bilan bog'lanishda xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring yoki ma'lumotlarni qo'lda kiriting."
                });
        }

        // Try to deserialize the error response to WbApiErrorObject
        WbApiError error;
        try
        {
            var errorObject = JsonConvert.DeserializeObject<WbApiErrorObject>(content);
            if (errorObject == null)
            {
                throw new WbClientException()
                    .WithSeverity(WbExceptionSeverity.MEDIUM)
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "EXTERNAL_SERVICE_ERROR",
                        ErrorMessage = "Tashqi xizmatdan kelgan javob noto'g'ri formatda. Iltimos, keyinroq qayta urinib ko'ring."
                    });
            }
            error = (WbApiError)errorObject;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new WbClientException()
                .WithSeverity(WbExceptionSeverity.MEDIUM)
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "EXTERNAL_SERVICE_ERROR",
                    ErrorMessage = "Tashqi xizmatdan kelgan javobni o'qishda xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring."
                });
        }

        if (error.ErrorType == WbExceptionType.SERVER)
        {
            throw new WbServerException(error).WithApiError(error);
        }
        else if (error.ErrorType == WbExceptionType.CLIENT)
        {
            throw new WbClientException(error).WithApiError(error);
        }
    }
}

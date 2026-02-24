using Microsoft.AspNetCore.Http;
using System.Text;

namespace WEBASE.LogSdk.Core.Helpers;

public class RequestHelper
{
    /// <summary>
    /// Request body'ni o‘qiydi va string holatda qaytaradi. Buffering yoqiladi.
    /// </summary>
    /// <param name="context">HTTP konteksti</param>
    /// <param name="includeBody">Agar false bo‘lsa, o‘qilmaydi</param>
    /// <returns>Request body matni</returns>

    public static async Task<string> ReadRequestBodyOrDefaultAsync(HttpContext context, bool includeBody)
    {
        // Check if the request body has already been read
        if (!includeBody)
            return null;

        // Check if the request body is null
        if (context.Request.Body == null)
            return null;

        // read the request body
        using (var reader = new StreamReader(context.Request.Body))
        {
            // Reset the request body stream position to the beginning
            context.Request.Body.Position = 0;

            // Read the request body
            var body = await reader.ReadToEndAsync();

            // Reset the request body stream position to the beginning again
            context.Request.Body.Position = 0;
            return body;
        }
    }

    public static async Task<string> ReadRequestBodyAsync(HttpContext context, bool includeBody)
    {
        if (!includeBody)
            return String.Empty;

        //// Check if the Content-Type starts with "application/json"
        //if (!context.Request.ContentType?.StartsWith("application/json", StringComparison.OrdinalIgnoreCase) ?? true)
        //    return string.Empty;

        // Enable buffering to allow multiple reads
        context.Request.EnableBuffering();

        // Read the request body as a string
        using (var memoryStream = new MemoryStream())
        {
            context.Request.Body.Position = 0; // Reset the stream position for further processing
            await context.Request.Body.CopyToAsync(memoryStream);
            context.Request.Body.Position = 0; // Reset the stream position for further processing

            memoryStream.Position = 0; // Reset the memory stream position to start reading
            using (var reader = new StreamReader(memoryStream, Encoding.UTF8, leaveOpen: true))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

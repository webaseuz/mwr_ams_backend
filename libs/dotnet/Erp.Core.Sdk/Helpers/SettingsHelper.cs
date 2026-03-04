using System.Text.Json;
using Erp.Core.Extensions;
using Refit;

namespace Erp.Core.Sdk;

public class SettingsHelper
{
    public static RefitSettings GetDefaultSettings()
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        // DateTime converter qo‘shamiz
        jsonOptions.Converters.Add(new BffDateTimeConverter());
        return new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
        };
        //return new RefitSettings
        //{
        //    ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
        //    {
        //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //        PropertyNameCaseInsensitive = true
        //    })
        //};
    }
}

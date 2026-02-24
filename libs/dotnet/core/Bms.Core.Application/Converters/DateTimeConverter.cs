using Bms.WEBASE.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Bms.Core.Application;

public class DateTimeConverter : IsoDateTimeConverter
{
}

public class DateNullableJsonConverter : JsonConverter<DateTime?>
{
    private const string DateFormat = WbConstants.DATE_FORMAT;

    public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
            return null;

        return DateTime.ParseExact((string)reader.Value, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateTime? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value == null ? "null" : value.Value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
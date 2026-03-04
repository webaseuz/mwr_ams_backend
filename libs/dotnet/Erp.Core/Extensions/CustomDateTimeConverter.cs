using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Erp.Core.Extensions;

public class CustomDateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
{
    private readonly string[] _formats =
    {
        "dd.MM.yyyy",
        "MM.dd.yyyy",
        "yyyy-MM-dd",
        "dd/MM/yyyy",
        "yyyy/MM/dd",
        "dd-MM-yyyy",
        "yyyy.MM.dd",
        "yyyy-MM-ddTHH:mm:ss",
        "dd.MM.yyyy HH:mm:ss",
        "yyyy-MM-ddTHH:mm:ssZ"
    };

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();

        if (string.IsNullOrEmpty(dateString))
        {
            throw new System.Text.Json.JsonException("Date value is null or empty");
        }

        foreach (var format in _formats)
        {
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        if (DateTime.TryParse(dateString, out var fallbackDate))
        {
            return fallbackDate;
        }

        throw new System.Text.Json.JsonException($"Unable to parse date: {dateString}. Expected format: dd.MM.yyyy");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var format = "dd.MM.yyyy"; // default

        // Yoki turli shart bo'yicha
        if (value.TimeOfDay != TimeSpan.Zero)
        {
            // Agar vaqt bor bo'lsa - to'liq format
            format = "dd.MM.yyyy HH:mm:ss";
        }
        writer.WriteStringValue(value.ToString(format));
    }
}
public class CustomDateTimeNullableConverter : System.Text.Json.Serialization.JsonConverter<DateTime?>
{
    private readonly string[] _formats =
    {
        "dd.MM.yyyy",
        "MM.dd.yyyy",
        "yyyy-MM-dd",
        "dd/MM/yyyy",
        "yyyy/MM/dd",
        "dd-MM-yyyy",
        "yyyy.MM.dd",
        "yyyy-MM-ddTHH:mm:ss",
        "dd.MM.yyyy HH:mm:ss",
        "yyyy-MM-ddTHH:mm:ssZ"
    };

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();

        if (string.IsNullOrEmpty(dateString))
        {
            throw new System.Text.Json.JsonException("Date value is null or empty");
        }

        foreach (var format in _formats)
        {
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        if (DateTime.TryParse(dateString, out var fallbackDate))
        {
            return fallbackDate;
        }

        throw new System.Text.Json.JsonException($"Unable to parse date: {dateString}. Expected format: dd.MM.yyyy");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        var format = "dd.MM.yyyy"; // default

        // Yoki turli shart bo'yicha
        if (value.Value.TimeOfDay != TimeSpan.Zero)
        {
            // Agar vaqt bor bo'lsa - to'liq format
            format = "dd.MM.yyyy HH:mm:ss";
        }
        writer.WriteStringValue(value.Value.ToString(format));
    }
}

public class DateTimeMinuteNullableConverter : System.Text.Json.Serialization.JsonConverter<DateTime?>
{
    private readonly string _dateTimeFormat = DateConstants.DATE_TIME_MINUTE_FORMAT;

    // MUHIM: Faqat nullable DateTime uchun
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime?);
    }

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();

        if (string.IsNullOrEmpty(dateString))
        {
            return null;
        }
        
        // Avval o'z formatimizni try qilamiz
        if (DateTime.TryParseExact(dateString, _dateTimeFormat,
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
        {
            return dateTime;
        }

        // Fallback - agar boshqa formatda kelsa
        if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var parsedDateTime))
        {
            return parsedDateTime;
        }

        throw new System.Text.Json.JsonException($"'{dateString}' satrini '{_dateTimeFormat}' formatida DateTime ga konvertatsiya qilib bo'lmadi.");
    }
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(_dateTimeFormat));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
public class SmartDateTimeConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?);
    }

    public override System.Text.Json.Serialization.JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(DateTime?))
        {
            return new CustomDateTimeNullableConverter();
        }

        return new CustomDateTimeConverter();
    }
}

/// <summary>
/// System.Text.Json converter for DateOnly — supports multiple date formats
/// (dd.MM.yyyy, yyyy-MM-dd, etc.) for both integration and UI sources.
/// </summary>
public class SmartDateOnlyConverter : System.Text.Json.Serialization.JsonConverter<DateOnly>
{
    private static readonly string[] _formats =
    {
        "dd.MM.yyyy",
        "yyyy-MM-dd",
        "MM.dd.yyyy",
        "dd/MM/yyyy",
        "yyyy/MM/dd",
        "dd-MM-yyyy",
        "yyyy.MM.dd"
    };

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();

        if (string.IsNullOrEmpty(dateString))
            throw new System.Text.Json.JsonException("DateOnly value is null or empty");

        foreach (var format in _formats)
        {
            if (DateOnly.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return date;
        }

        // Fallback — DateTime.TryParse orqali
        if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None, out var fallbackDt))
            return DateOnly.FromDateTime(fallbackDt);

        throw new System.Text.Json.JsonException($"Unable to parse DateOnly: '{dateString}'. Supported formats: dd.MM.yyyy, yyyy-MM-dd");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("dd.MM.yyyy"));
    }
}

/// <summary>
/// System.Text.Json converter for DateOnly? (nullable) — supports multiple date formats.
/// </summary>
public class SmartDateOnlyNullableConverter : System.Text.Json.Serialization.JsonConverter<DateOnly?>
{
    private static readonly string[] _formats =
    {
        "dd.MM.yyyy",
        "yyyy-MM-dd",
        "MM.dd.yyyy",
        "dd/MM/yyyy",
        "yyyy/MM/dd",
        "dd-MM-yyyy",
        "yyyy.MM.dd"
    };

    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        var dateString = reader.GetString();

        if (string.IsNullOrEmpty(dateString))
            return null;

        foreach (var format in _formats)
        {
            if (DateOnly.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return date;
        }

        // Fallback — DateTime.TryParse orqali
        if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None, out var fallbackDt))
            return DateOnly.FromDateTime(fallbackDt);

        throw new System.Text.Json.JsonException($"Unable to parse DateOnly: '{dateString}'. Supported formats: dd.MM.yyyy, yyyy-MM-dd");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString("dd.MM.yyyy"));
        else
            writer.WriteNullValue();
    }
}

/// <summary>
/// Factory for DateOnly/DateOnly? — SmartDateTimeConverterFactory bilan bir xil pattern.
/// Program.cs da global registratsiya uchun.
/// </summary>
public class SmartDateOnlyConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateOnly) || typeToConvert == typeof(DateOnly?);
    }

    public override System.Text.Json.Serialization.JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(DateOnly?))
            return new SmartDateOnlyNullableConverter();

        return new SmartDateOnlyConverter();
    }
}

public class DateTimeMinuteConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
{
    private readonly string _dateTimeFormat = DateConstants.DATE_TIME_MINUTE_FORMAT;
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();

        if (string.IsNullOrEmpty(dateString))
        {
            return default;
        }

        if (DateTime.TryParseExact(dateString, _dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
        {
            return dateTime;
        }

        throw new System.Text.Json.JsonException($"'{dateString}' satrini '{_dateTimeFormat}' formatida DateTime ga konvertatsiya qilib bo'lmadi.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_dateTimeFormat, CultureInfo.InvariantCulture));
    }
}

public class DateTimeConverter : IsoDateTimeConverter
{
    public DateTimeConverter()
    {
        base.DateTimeFormat = DateConstants.DATE_TIME_FORMAT;
    }
}
public class DateOnlyConverter : IsoDateTimeConverter
{
    public DateOnlyConverter()
    {
        base.DateTimeFormat = DateConstants.DATE_FORMAT;
    }
}
public class HTimeConverter : IsoDateTimeConverter
{
    public HTimeConverter()
    {
        base.DateTimeFormat = DateConstants.TIME_MINUTE_FORMAT;
    }
}
public class HDateTimeConverter : IsoDateTimeConverter
{
    public HDateTimeConverter()
    {
        base.DateTimeFormat = DateConstants.H_DATE_TIME_FORMAT;
    }
}

public class TimeOnlyConverter : Newtonsoft.Json.JsonConverter<TimeOnly>
{
    public TimeOnlyConverter()
    {
    }

    public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        return TimeOnly.ParseExact(reader.Value as string, DateConstants.TIME_MINUTE_FORMAT, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, TimeOnly value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(DateConstants.TIME_MINUTE_FORMAT, CultureInfo.InvariantCulture));
    }
}
public class DateOnlyJsonConverter : Newtonsoft.Json.JsonConverter<DateOnly>
{
    private const string DateFormat = DateConstants.DATE_FORMAT;

    public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.Value.GetType() == typeof(DateTime))
        {
            return DateOnly.FromDateTime((DateTime)reader.Value);
        }
        return DateOnly.ParseExact((string)reader.Value, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateOnly value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
public class DateTimeJsonConverter : Newtonsoft.Json.JsonConverter<DateTime>
{
    private const string DateFormat = DateConstants.DATE_TIME_FORMAT;

    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.Value.GetType() == typeof(DateTime))
        {
            return (DateTime)reader.Value;
        }
        return DateTime.ParseExact((string)reader.Value, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateTime value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
public class DateTimeItgNullableJsonConverter : Newtonsoft.Json.JsonConverter<DateTime?>
{
    private const string DateFormat = DateConstants.DATE_TIME_FORMAT_ITG;

    public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
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
public class ManualIsoDateTimeConverter : Newtonsoft.Json.JsonConverter
{
    private const string Format = "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz";

    public override bool CanConvert(Type objectType) =>
        objectType == typeof(DateTime) || objectType == typeof(DateTime?);

    public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        var dt = (DateTime)value;
        writer.WriteValue(dt.ToString(Format));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
        {
            if (objectType == typeof(DateTime?))
                return null;

            throw new JsonSerializationException("Cannot convert null value to DateTime.");
        }

        if (reader.Value is DateTime dt)
        {
            return dt; // ✅ Already parsed, return as-is
        }

        if (reader.Value is string str)
        {
            return DateTime.ParseExact(str, Format, CultureInfo.InvariantCulture);
        }

        throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}");
    }

}
public class DateNullableJsonConverter : Newtonsoft.Json.JsonConverter<DateTime?>
{
    private const string DateFormat = DateConstants.DATE_FORMAT;

    public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
            return null;

        if (reader.Value is DateTime value) return value;

        return DateTime.ParseExact((string)reader.Value, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateTime? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value == null ? "null" : value.Value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
public class TimeOnlyJsonConverter : Newtonsoft.Json.JsonConverter<TimeOnly>
{
    private const string TimeFormat = DateConstants.TIME_MINUTE_FORMAT;

    public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        return TimeOnly.ParseExact((string)reader.Value, TimeFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, TimeOnly value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}
public class DateOnlyNullableJsonConverter : Newtonsoft.Json.JsonConverter<DateOnly?>
{
    private const string DateFormat = DateConstants.DATE_FORMAT;

    public override DateOnly? ReadJson(JsonReader reader, Type objectType, DateOnly? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
            return null;

        if (reader.Value.GetType() == typeof(DateTime))
            return DateOnly.FromDateTime((DateTime)reader.Value);

        return DateOnly.ParseExact((string)reader.Value, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateOnly? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value == null ? "null" : value.Value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
public class TimeOnlyNullableJsonConverter : Newtonsoft.Json.JsonConverter<TimeOnly?>
{
    private const string TimeFormat = DateConstants.TIME_MINUTE_FORMAT;

    public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
            return null;

        return TimeOnly.ParseExact((string)reader.Value, TimeFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, TimeOnly? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        writer.WriteValue(value == null ? "null" : value.Value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}
public class TimeSpanJsonConverter : Newtonsoft.Json.JsonConverter<TimeSpan?>
{
    public override TimeSpan? ReadJson(JsonReader reader, Type objectType, TimeSpan? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.Value == null) return null;
        var valueString = reader.Value.ToString();
        if (string.IsNullOrEmpty(valueString)) return null;

        // Parse the string "DD HH:mm" back to TimeSpan
        var parts = valueString.Split(' ');
        if (parts.Length != 2) throw new Newtonsoft.Json.JsonException("Invalid TimeSpan format.");

        int days = int.Parse(parts[0]);
        var timeParts = parts[1].Split(':');
        int hours = int.Parse(timeParts[0]);
        int minutes = int.Parse(timeParts[1]);

        return new TimeSpan(days, hours, minutes, 0);
    }
    public override void WriteJson(JsonWriter writer, TimeSpan? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        // Format TimeSpan as "DD HH:mm"
        var ts = value.Value;
        string formatted = $"{ts.Days:00} {ts.Hours:00}:{ts.Minutes:00}";
        writer.WriteValue(formatted);
    }
}
public class DecimalItgJsonConverter : Newtonsoft.Json.JsonConverter<decimal>
{
    public override void WriteJson(JsonWriter writer, decimal value, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (value == Math.Floor(value))
            writer.WriteValue((long)value);
        else
            writer.WriteValue(value);
    }

    public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue,
        bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        return Convert.ToDecimal(reader.Value);
    }
}

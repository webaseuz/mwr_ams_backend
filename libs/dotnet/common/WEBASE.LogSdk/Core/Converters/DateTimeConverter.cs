using Newtonsoft.Json.Converters;

namespace WEBASE.LogSdk.Converters;

/// <summary>
/// Custom DateTime converter for JSON serialization.
/// </summary>
public class DateTimeConverter : IsoDateTimeConverter
{
    public DateTimeConverter()
    {
        base.DateTimeFormat = Constsnts.Constants.DATE_TIME_FORMAT;
    }
}

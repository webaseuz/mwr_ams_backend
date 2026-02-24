using Bms.WEBASE.Constants;
using Newtonsoft.Json.Converters;

namespace Bms.WEBASE.Helpers;

public class WbDateConverter : IsoDateTimeConverter
{
    public WbDateConverter()
    {
        DateTimeFormat = WbConstants.DATE_FORMAT;
    }
}

public class WbDateTimeConverter : IsoDateTimeConverter
{
    public WbDateTimeConverter()
    {
        DateTimeFormat = WbConstants.DATE_TIME_FORMAT;
    }
}

public class WbDateTimeMinuteConverter : IsoDateTimeConverter
{
    public WbDateTimeMinuteConverter()
    {
        DateTimeFormat = WbConstants.DATE_TIME_MINUTE_FORMAT;
    }
}




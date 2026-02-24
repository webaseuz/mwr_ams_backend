using Bms.Core.Application;
using Bms.Core.Domain;
using Npgsql;
using System.Data;
using System.Globalization;

namespace Bms.Core.Infrastructure;

public class DateTimeHelper : IDateTimeHelper
{
    private NpgsqlConnection _connection = null;

    public DateTimeHelper(PgSqlConfig config)
    {
        _connection = new NpgsqlConnection(config.ConnectionString);
    }


    public DateTime GetDateTimeNow()
    {
        if (_connection.State == ConnectionState.Closed)
            _connection.Open();

        using var command = _connection.CreateCommand();

        command.CommandText = "SELECT CURRENT_TIMESTAMP";

        return (DateTime)command.ExecuteScalar();
    }


    public void Dispose()
    {
        _connection?.Dispose();
        _connection = null;
    }

    public static DateTime? ParseDateTime(string dateToParse, string[] formats = null, IFormatProvider provider = null, DateTimeStyles styles = DateTimeStyles.None)
    {
        string[] array = new string[14]
        {
            "dd.MM.yyyy", "dd.MM.yyyy HH:mm:ss", "yyyyMMddTHHmmssZ", "yyyyMMddTHHmmZ", "yyyyMMddTHHmmss", "yyyyMMddTHHmm", "yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyyMMdd", "yyyy-MM-ddTHH-mm-ss",
            "yyyy-MM-dd-HH-mm-ss", "yyyy-MM-dd-HH-mm", "yyyy-MM-dd", "MM-dd-yyyy"
        };
        if (formats == null || !formats.Any())
        {
            formats = array;
        }

        string[] array2 = formats;
        foreach (string text in array2)
        {
            if (text.EndsWith("Z") && DateTime.TryParseExact(dateToParse, text, provider, DateTimeStyles.AssumeUniversal, out var result))
            {
                return result;
            }

            if (DateTime.TryParseExact(dateToParse, text, provider, styles, out result))
            {
                return result;
            }
        }

        return null;
    }

    public static bool IsNullableType(Type type)
    {
        if (type.IsGenericType)
        {
            return type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        return false;
    }
}

using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace Bms.Core.Application;

public class HintInterceptor :
    DbCommandInterceptor
{
    private static readonly Regex _tableAliasRegex = new Regex(@"(?<tableAlias>FROM +(\[.*\]\.)?(\[.*\]) AS (\[.*\])(?! WITH \(*HINT*\)))", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

    [ThreadStatic]
    public static string HintValue;

    private static string Replace(string input)
    {
        if (!string.IsNullOrWhiteSpace(HintValue))
        {
            input = string.Concat(input, " ", HintValue);
        }
        HintValue = string.Empty;
        return input;
    }

    public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
    {
        command.CommandText = Replace(command.CommandText);
        return base.ScalarExecuting(command, eventData, result);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        command.CommandText = Replace(command.CommandText);
        return base.ReaderExecuting(command, eventData, result);
    }

}
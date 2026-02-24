namespace WEBASE.LogSdk.Core.Extensions;

public static class StringExtensions
{
    public static string SubstringByLength(this string str, int maxLength)
    {
        if (!string.IsNullOrEmpty(str) && str.Length > maxLength)
            return str.Substring(0, maxLength);

        return str;
    }
}

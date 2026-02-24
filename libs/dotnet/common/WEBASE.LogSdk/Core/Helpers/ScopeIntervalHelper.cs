namespace WEBASE.LogSdk.Core.Helpers;
public class ScopeIntervalHelper
{
    /// <summary>
    /// Berilgan sana asosida "yyyy_MM_dd" formatida kalit hosil qiladi.
    /// Masalan: 2025-04-23 → "2025_04_23"
    /// </summary>
    /// <param name="dateTime">Sana</param>
    /// <returns>Formatlangan string kalit</returns>
    public static string GetKey(DateTime dateTime)
    {
        return dateTime.ToString("yyyy_MM_dd");
    }
}
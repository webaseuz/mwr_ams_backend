namespace Erp.Core.Service.Infrastructure.Localization;

/// <summary>
/// Configuration options for localization service
/// </summary>
public class LocalizationOptions
{
    /// <summary>
    /// Google Sheets export URL for translations
    /// Supported formats:
    /// - CSV: https://docs.google.com/spreadsheets/d/{SHEET_ID}/export?format=csv&gid={GID}
    /// - Excel: https://docs.google.com/spreadsheets/d/{SHEET_ID}/export?format=xlsx
    /// </summary>
    public string GoogleSheetsUrl { get; set; } = "https://opensheet.elk.sh/1mLfkUU3Ud3Or2InZk6gGKU4GaRPFhgTN6PuRfdNySJ8/back";

    /// <summary>
    /// Format of the Google Sheets export (csv or xlsx)
    /// Default: csv
    /// </summary>
    public string GoogleSheetsFormat { get; set; } = "json";

    /// <summary>
    /// Enable automatic refresh of translations from Google Sheets
    /// </summary>
    public bool EnableAutoRefresh { get; set; } = false;

    /// <summary>
    /// Auto-refresh interval in minutes (default: 60 minutes)
    /// </summary>
    public int AutoRefreshIntervalMinutes { get; set; } = 60;

    /// <summary>
    /// Cache duration for translations in minutes (default: 30 minutes)
    /// </summary>
    public int CacheDurationMinutes { get; set; } = 30;
}

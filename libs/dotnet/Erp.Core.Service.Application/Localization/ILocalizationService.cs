namespace Erp.Core.Service.Application.Localization;

/// <summary>
/// Service for multi-language localization using Stubble templates
/// Supports loading translations from Google Sheets
/// </summary>
public interface ILocalizationService
{
    /// <summary>
    /// Gets localized string for the given key using current user's culture
    /// </summary>
    /// <param name="key">Localization key (e.g., "CANNOT_CHANGE_STATUS")</param>
    /// <param name="data">Optional data for Mustache template placeholders</param>
    /// <returns>Localized string with data interpolated</returns>
    string GetString(string key, object data = null);

    /// <summary>
    /// Gets localized string for the given key using specified culture
    /// </summary>
    /// <param name="cultureId">Culture ID (use LanguageIdConst)</param>
    /// <param name="key">Localization key (e.g., "CANNOT_CHANGE_STATUS")</param>
    /// <param name="data">Optional data for Mustache template placeholders</param>
    /// <returns>Localized string with data interpolated</returns>
    string GetString(int cultureId, string key, object data = null);

    /// <summary>
    /// Refreshes translations from Google Sheets
    /// Call this method to reload translations without restarting the service
    /// </summary>
    Task RefreshTranslationsAsync(CancellationToken cancellationToken = default);
}

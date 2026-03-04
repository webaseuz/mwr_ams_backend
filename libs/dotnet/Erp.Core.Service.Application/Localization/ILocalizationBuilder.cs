namespace Erp.Core.Service.Application.Localization;

/// <summary>
/// Fluent builder for creating localized strings with optional configuration
/// Note: Each call to For() creates a new builder instance to prevent state pollution
/// </summary>
public interface ILocalizationBuilder
{
    /// <summary>
    /// Starts building a localized string for the given key
    /// Creates a new builder instance to ensure state isolation
    /// </summary>
    /// <param name="key">Localization key (e.g., "CANNOT_CHANGE_STATUS")</param>
    /// <returns>New builder instance for fluent chaining</returns>
    ILocalizationBuilder For(string key);

    /// <summary>
    /// Sets the culture/language for this localization
    /// </summary>
    /// <param name="cultureId">Culture ID (use LanguageIdConst)</param>
    /// <returns>Builder for fluent chaining</returns>
    ILocalizationBuilder WithCulture(int cultureId);

    /// <summary>
    /// Sets the data/parameters for template interpolation
    /// </summary>
    /// <param name="data">Anonymous object or dictionary with template parameters</param>
    /// <returns>Builder for fluent chaining</returns>
    ILocalizationBuilder WithData(object data);

    /// <summary>
    /// Sets a fallback value if the translation key is not found
    /// </summary>
    /// <param name="fallback">Fallback string to use</param>
    /// <returns>Builder for fluent chaining</returns>
    ILocalizationBuilder WithFallback(string fallback);

    /// <summary>
    /// Builds and returns the localized string
    /// Uses current user's culture if not specified
    /// </summary>
    /// <returns>Localized and interpolated string</returns>
    string Build();

    /// <summary>
    /// Implicitly converts the builder to a string by calling Build()
    /// Allows usage like: string message = localization.For("KEY");
    /// </summary>
    string ToString();
}

using Erp.Core.Service.Application.Localization;

namespace Erp.Core.Service.Infrastructure.Localization;

/// <summary>
/// Fluent builder implementation for creating localized strings
/// </summary>
public class LocalizationBuilder : ILocalizationBuilder
{
    private readonly ILocalizationService _localizationService;
    private string _key;
    private int? _cultureId;
    private object _data;
    private string _fallback;

    public LocalizationBuilder(ILocalizationService localizationService)
    {
        _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
    }

    /// <inheritdoc/>
    public ILocalizationBuilder For(string key)
    {
        // Create new instance to avoid state pollution across multiple calls
        return new LocalizationBuilder(_localizationService)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key))
        };
    }

    /// <inheritdoc/>
    public ILocalizationBuilder WithCulture(int cultureId)
    {
        _cultureId = cultureId;
        return this;
    }

    /// <inheritdoc/>
    public ILocalizationBuilder WithData(object data)
    {
        _data = data;
        return this;
    }

    /// <inheritdoc/>
    public ILocalizationBuilder WithFallback(string fallback)
    {
        _fallback = fallback;
        return this;
    }

    /// <inheritdoc/>
    public string Build()
    {
        if (string.IsNullOrEmpty(_key))
            throw new InvalidOperationException("Localization key must be set using For() method before calling Build()");

        try
        {
            // Use specific culture if provided, otherwise use current user's culture
            if (_cultureId.HasValue)
            {
                return _localizationService.GetString(_cultureId.Value, _key, _data);
            }
            else
            {
                return _localizationService.GetString(_key, _data);
            }
        }
        catch (Exception)
        {
            // If translation fails and fallback is provided, return fallback
            if (!string.IsNullOrEmpty(_fallback))
            {
                return _fallback;
            }

            // Re-throw if no fallback
            throw;
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Build();
    }

    /// <summary>
    /// Implicit conversion to string for convenience
    /// Allows usage like: string message = localization.For("KEY");
    /// </summary>
    public static implicit operator string(LocalizationBuilder builder)
    {
        return builder?.Build();
    }
}

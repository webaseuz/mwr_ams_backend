using Erp.Core.Service.Application.Localization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using Stubble.Core;
using Stubble.Core.Builders;
using WEBASE.i18n;

namespace Erp.Core.Service.Infrastructure.Localization;

/// <summary>
/// Localization service with Google Sheets integration and Stubble templating
/// </summary>
public class LocalizationService : ILocalizationService
{
    private readonly ICultureHelper _cultureHelper;
    private readonly ILogger<LocalizationService> _logger;
    private readonly IMemoryCache _cache;
    private readonly LocalizationOptions _options;
    private readonly StubbleVisitorRenderer _stubble;
    private readonly HttpClient _httpClient;
    private readonly SemaphoreSlim _refreshLock = new(1, 1);

    private const string CACHE_KEY = "LocalizationTranslations";

    public LocalizationService(
        ICultureHelper cultureHelper,
        ILogger<LocalizationService> logger,
        IMemoryCache cache,
        IOptions<LocalizationOptions> options,
        IHttpClientFactory httpClientFactory,
        IServiceProvider serviceProvider)
    {
        _cultureHelper = cultureHelper;
        _logger = logger;
        _cache = cache;
        _options = options.Value;
        _stubble = new StubbleBuilder()
            .Configure(settings => settings.SetIgnoreCaseOnKeyLookup(true))
            .Build();
        _httpClient = httpClientFactory.CreateClient();

        // Set EPPlus license context (required for EPPlus 5+)
        // Using NonCommercial for internal business applications
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Initialize translations on startup
        _ = InitializeTranslationsAsync();
    }

    public string GetString(string key, object data = null)
    {
        var cultureId = _cultureHelper.CurrentCulture.Id;

        return GetString(cultureId, key, data);
    }

    public string GetString(int cultureId, string key, object data = null)
    {
        try
        {
            var templates = GetTemplates();
            if (!templates.ContainsKey(key))
            {
                _logger.LogWarning("Translation key '{Key}' not found", key);
                return FormatKeyWithData(key, data); // Modified fallback
            }

            var languageTemplates = templates[key];

            string template;
            if (languageTemplates.ContainsKey(cultureId))
            {
                template = languageTemplates[cultureId];
            }
            else if (languageTemplates.ContainsKey(LanguageIdConst.UZ_LATN))
            {
                template = languageTemplates[LanguageIdConst.UZ_LATN];
                _logger.LogDebug("Culture {CultureId} not found for key '{Key}', falling back to UZ_LATN", cultureId, key);
            }
            else if (languageTemplates.Count > 0)
            {
                template = languageTemplates.First().Value;
                _logger.LogDebug("Neither requested culture {CultureId} nor UZ_LATN found for key '{Key}', using first available culture", cultureId, key);
            }
            else
            {
                _logger.LogWarning("No translations found for key '{Key}', returning key with data", key);
                return FormatKeyWithData(key, data); // Modified fallback
            }

            return _stubble.Render(template, data ?? new { });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error rendering localized string for key '{Key}'", key);
            return FormatKeyWithData(key, data); // Modified fallback
        }
    }

    public async Task RefreshTranslationsAsync(CancellationToken cancellationToken = default)
    {
        await _refreshLock.WaitAsync(cancellationToken);
        try
        {
            _logger.LogInformation("Refreshing translations from Google Sheets...");

            if (string.IsNullOrEmpty(_options.GoogleSheetsUrl))
            {
                _logger.LogWarning("Google Sheets URL not configured");
                return;
            }

            var templates = await LoadTranslationsFromGoogleSheetsAsync();

            if (templates != null && templates.Count > 0)
            {
                _cache.Set(CACHE_KEY, templates, TimeSpan.FromMinutes(_options.CacheDurationMinutes));
                _logger.LogInformation("Loaded {Count} translation keys from Google Sheets ({Format} format)",
                    templates.Count, _options.GoogleSheetsFormat);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error refreshing translations from Google Sheets");
        }
        finally
        {
            _refreshLock.Release();
        }
    }

    private async Task InitializeTranslationsAsync()
    {
        if (!string.IsNullOrEmpty(_options.GoogleSheetsUrl))
        {
            await RefreshTranslationsAsync();
        }
        else
        {
            _logger.LogWarning("Google Sheets URL not configured. Translations will return keys as-is.");
        }
    }

    private Dictionary<string, Dictionary<int, string>> GetTemplates()
    {
        if (_cache.TryGetValue<Dictionary<string, Dictionary<int, string>>>(CACHE_KEY, out var cachedTemplates))
        {
            return cachedTemplates;
        }

        // If cache is empty, return empty dictionary (keys will be returned as-is)
        _logger.LogWarning("Translation cache is empty. Keys will be returned as-is.");
        return new Dictionary<string, Dictionary<int, string>>();
    }

    /// <summary>
    /// Load translations from Google Sheets export (CSV, Excel, or JSON)
    /// Expected format:
    /// Key,UZ_LATN,UZ_CYRL,RU,EN
    /// CANNOT_CHANGE_STATUS,"{{entityName}} holatini o'zgartirib bo'lmaydi","{{entityName}} ҳолатини ўзгартириб бўлмайди","Невозможно изменить статус документа {{entityName}}","Cannot change {{entityName}} status"
    /// </summary>
    private async Task<Dictionary<string, Dictionary<int, string>>> LoadTranslationsFromGoogleSheetsAsync()
    {
        try
        {
            var format = _options.GoogleSheetsFormat?.ToLowerInvariant() ?? "csv";

            if (format == "json")
            {
                return await LoadTranslationsFromJsonAsync();
            }
            else if (format == "xlsx" || format == "excel")
            {
                return await LoadTranslationsFromExcelAsync();
            }
            else
            {
                return await LoadTranslationsFromCsvAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load translations from Google Sheets");
            return new Dictionary<string, Dictionary<int, string>>();
        }
    }

    /// <summary>
    /// Load translations from CSV format
    /// </summary>
    private async Task<Dictionary<string, Dictionary<int, string>>> LoadTranslationsFromCsvAsync()
    {
        try
        {
            var csv = await _httpClient.GetStringAsync(_options.GoogleSheetsUrl);
            return ParseCsvTranslations(csv);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to download CSV from Google Sheets");
            return new Dictionary<string, Dictionary<int, string>>();
        }
    }

    /// <summary>
    /// Load translations from JSON format
    /// Expected format: Array of objects with Key, UZ_LATN, UZ_CYRL, RU, EN properties (or oz, uz alternatives)
    /// </summary>
    private async Task<Dictionary<string, Dictionary<int, string>>> LoadTranslationsFromJsonAsync()
    {
        try
        {
            _logger.LogInformation("Downloading JSON from: {Url}", _options.GoogleSheetsUrl);
            var json = await _httpClient.GetStringAsync(_options.GoogleSheetsUrl);
            _logger.LogInformation("Downloaded {Size} characters from API", json.Length);

            var translations = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);

            if (translations == null || translations.Count == 0)
            {
                _logger.LogWarning("No translations found in JSON response");
                return new Dictionary<string, Dictionary<int, string>>();
            }

            var templates = new Dictionary<string, Dictionary<int, string>>();

            foreach (var row in translations)
            {
                // Get key (case-insensitive)
                var key = row.FirstOrDefault(kvp => kvp.Key.Equals("Key", StringComparison.OrdinalIgnoreCase)).Value;

                if (string.IsNullOrWhiteSpace(key))
                    continue;

                templates[key] = new Dictionary<int, string>();

                // UZ_LATN or oz
                var uzLatn = row.FirstOrDefault(kvp =>
                    kvp.Key.Equals("UZ_LATN", StringComparison.OrdinalIgnoreCase) ||
                    kvp.Key.Equals("oz", StringComparison.OrdinalIgnoreCase)).Value;
                if (!string.IsNullOrEmpty(uzLatn))
                    templates[key][LanguageIdConst.UZ_LATN] = uzLatn;

                // UZ_CYRL or uz
                var uzCyrl = row.FirstOrDefault(kvp =>
                    kvp.Key.Equals("UZ_CYRL", StringComparison.OrdinalIgnoreCase) ||
                    kvp.Key.Equals("uz", StringComparison.OrdinalIgnoreCase)).Value;
                if (!string.IsNullOrEmpty(uzCyrl))
                    templates[key][LanguageIdConst.UZ_CYRL] = uzCyrl;

                // RU or ru
                var ru = row.FirstOrDefault(kvp =>
                    kvp.Key.Equals("RU", StringComparison.OrdinalIgnoreCase) ||
                    kvp.Key.Equals("ru", StringComparison.OrdinalIgnoreCase)).Value;
                if (!string.IsNullOrEmpty(ru))
                    templates[key][LanguageIdConst.RU] = ru;

                // EN or en
                var en = row.FirstOrDefault(kvp =>
                    kvp.Key.Equals("EN", StringComparison.OrdinalIgnoreCase) ||
                    kvp.Key.Equals("en", StringComparison.OrdinalIgnoreCase)).Value;
                if (!string.IsNullOrEmpty(en))
                    templates[key][LanguageIdConst.EN] = en;
            }

            _logger.LogInformation("Loaded {Count} translation keys from JSON", templates.Count);
            return templates;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to download JSON from API. URL: {Url}", _options.GoogleSheetsUrl);
            return new Dictionary<string, Dictionary<int, string>>();
        }
        catch (System.Text.Json.JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse JSON response. Invalid JSON format.");
            return new Dictionary<string, Dictionary<int, string>>();
        }
    }

    /// <summary>
    /// Load translations from Excel format
    /// </summary>
    private async Task<Dictionary<string, Dictionary<int, string>>> LoadTranslationsFromExcelAsync()
    {
        try
        {
            _logger.LogInformation("Downloading Excel from: {Url}", _options.GoogleSheetsUrl);
            var excelBytes = await _httpClient.GetByteArrayAsync(_options.GoogleSheetsUrl);
            _logger.LogInformation("Downloaded {Size} bytes from Google Sheets", excelBytes.Length);

            // Check if downloaded content is actually HTML (common error when URL is wrong)
            if (excelBytes.Length > 0 && excelBytes[0] == '<')
            {
                var preview = System.Text.Encoding.UTF8.GetString(excelBytes.Take(200).ToArray());
                _logger.LogError("Downloaded content appears to be HTML, not Excel. URL may be incorrect. Preview: {Preview}", preview);
                _logger.LogError("Expected URL format: https://docs.google.com/spreadsheets/d/{{SHEET_ID}}/export?format=xlsx&gid={{GID}}");
                return new Dictionary<string, Dictionary<int, string>>();
            }

            using var stream = new MemoryStream(excelBytes);
            using var package = new ExcelPackage(stream);

            if (package.Workbook.Worksheets.Count == 0)
            {
                _logger.LogWarning("Excel file has no worksheets");
                return new Dictionary<string, Dictionary<int, string>>();
            }

            _logger.LogInformation("Excel file contains {Count} worksheet(s): {Worksheets}",
                package.Workbook.Worksheets.Count,
                string.Join(", ", package.Workbook.Worksheets.Select(w => w.Name)));

            // Try to find worksheet named "back"
            var worksheet = package.Workbook.Worksheets.FirstOrDefault(w =>
                w.Name.Trim().Equals("back", StringComparison.OrdinalIgnoreCase));

            if (worksheet == null)
            {
                _logger.LogWarning("Worksheet 'back' not found. Available worksheets: {Worksheets}",
                    string.Join(", ", package.Workbook.Worksheets.Select(w => w.Name)));
                return new Dictionary<string, Dictionary<int, string>>();
            }

            _logger.LogInformation("Found worksheet: {WorksheetName}", worksheet.Name);
            return ParseExcelTranslations(worksheet);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to download Excel from Google Sheets. URL: {Url}", _options.GoogleSheetsUrl);
            return new Dictionary<string, Dictionary<int, string>>();
        }
        catch (System.IO.InvalidDataException ex)
        {
            _logger.LogError(ex, "Downloaded file is not a valid Excel file. Please verify the Google Sheets URL uses the export format: /export?format=xlsx&gid={{GID}}");
            return new Dictionary<string, Dictionary<int, string>>();
        }
    }

    /// <summary>
    /// Parse CSV format: Key,UZ_LATN,UZ_CYRL,RU,EN
    /// </summary>
    private Dictionary<string, Dictionary<int, string>> ParseCsvTranslations(string csv)
    {
        try
        {
            var templates = new Dictionary<string, Dictionary<int, string>>();
            var lines = csv.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length < 2)
            {
                _logger.LogWarning("CSV has no data rows");
                return null;
            }

            // Parse header to get column indices
            var header = ParseCsvLine(lines[0]);
            var keyIndex = Array.IndexOf(header, "Key");
            var uzLatnIndex = Array.IndexOf(header, "UZ_LATN");
            var uzCyrlIndex = Array.IndexOf(header, "UZ_CYRL");
            var ruIndex = Array.IndexOf(header, "RU");
            var enIndex = Array.IndexOf(header, "EN");

            if (keyIndex == -1)
            {
                _logger.LogError("CSV header missing 'Key' column");
                return null;
            }

            // Parse data rows
            for (int i = 1; i < lines.Length; i++)
            {
                var columns = ParseCsvLine(lines[i]);

                if (columns.Length <= keyIndex)
                    continue;

                var key = columns[keyIndex];

                if (string.IsNullOrWhiteSpace(key))
                    continue;

                templates[key] = new Dictionary<int, string>();

                if (uzLatnIndex != -1 && columns.Length > uzLatnIndex)
                    templates[key][LanguageIdConst.UZ_LATN] = columns[uzLatnIndex];

                if (uzCyrlIndex != -1 && columns.Length > uzCyrlIndex)
                    templates[key][LanguageIdConst.UZ_CYRL] = columns[uzCyrlIndex];

                if (ruIndex != -1 && columns.Length > ruIndex)
                    templates[key][LanguageIdConst.RU] = columns[ruIndex];

                if (enIndex != -1 && columns.Length > enIndex)
                    templates[key][LanguageIdConst.EN] = columns[enIndex];
            }

            return templates;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing CSV translations");
            return new Dictionary<string, Dictionary<int, string>>();
        }
    }

    /// <summary>
    /// Parse Excel format: Key,UZ_LATN,UZ_CYRL,RU,EN
    /// </summary>
    private Dictionary<string, Dictionary<int, string>> ParseExcelTranslations(ExcelWorksheet worksheet)
    {
        try
        {
            var templates = new Dictionary<string, Dictionary<int, string>>();

            if (worksheet.Dimension == null)
            {
                _logger.LogWarning("Excel worksheet is empty");
                return templates;
            }

            var rowCount = worksheet.Dimension.End.Row;
            var colCount = worksheet.Dimension.End.Column;

            if (rowCount < 2)
            {
                _logger.LogWarning("Excel has no data rows");
                return templates;
            }

            // Parse header to get column indices (row 1)
            var keyIndex = -1;
            var uzLatnIndex = -1;
            var uzCyrlIndex = -1;
            var ruIndex = -1;
            var enIndex = -1;

            var headerColumns = new List<string>();
            for (int col = 1; col <= colCount; col++)
            {
                var headerValue = worksheet.Cells[1, col].Text?.Trim();
                if (string.IsNullOrEmpty(headerValue))
                    continue;

                headerColumns.Add(headerValue);

                // Case-insensitive column matching
                if (headerValue.Equals("Key", StringComparison.OrdinalIgnoreCase)) keyIndex = col;
                else if (headerValue.Equals("UZ_LATN", StringComparison.OrdinalIgnoreCase) ||
                         headerValue.Equals("oz", StringComparison.OrdinalIgnoreCase)) uzLatnIndex = col;
                else if (headerValue.Equals("UZ_CYRL", StringComparison.OrdinalIgnoreCase) ||
                         headerValue.Equals("uz", StringComparison.OrdinalIgnoreCase)) uzCyrlIndex = col;
                else if (headerValue.Equals("RU", StringComparison.OrdinalIgnoreCase) ||
                         headerValue.Equals("ru", StringComparison.OrdinalIgnoreCase)) ruIndex = col;
                else if (headerValue.Equals("EN", StringComparison.OrdinalIgnoreCase) ||
                         headerValue.Equals("en", StringComparison.OrdinalIgnoreCase)) enIndex = col;
            }

            if (keyIndex == -1)
            {
                _logger.LogError("Excel header missing 'Key' column. Found columns: {Columns}. Worksheet name: {WorksheetName}",
                    string.Join(", ", headerColumns.Select(c => $"'{c}'")),
                    worksheet.Name);
                _logger.LogError("Expected header format: Key, UZ_LATN, UZ_CYRL, RU, EN");

                // Log first few rows for debugging
                _logger.LogInformation("First 3 rows of data:");
                for (int row = 1; row <= Math.Min(3, rowCount); row++)
                {
                    var rowData = new List<string>();
                    for (int col = 1; col <= Math.Min(5, colCount); col++)
                    {
                        rowData.Add(worksheet.Cells[row, col].Text ?? "");
                    }
                    _logger.LogInformation("Row {Row}: {Data}", row, string.Join(" | ", rowData));
                }

                return templates;
            }

            // Parse data rows (starting from row 2)
            for (int row = 2; row <= rowCount; row++)
            {
                var key = worksheet.Cells[row, keyIndex].Text?.Trim();

                if (string.IsNullOrWhiteSpace(key))
                    continue;

                templates[key] = new Dictionary<int, string>();

                if (uzLatnIndex != -1)
                {
                    var value = worksheet.Cells[row, uzLatnIndex].Text?.Trim();
                    if (!string.IsNullOrEmpty(value))
                        templates[key][LanguageIdConst.UZ_LATN] = value;
                }

                if (uzCyrlIndex != -1)
                {
                    var value = worksheet.Cells[row, uzCyrlIndex].Text?.Trim();
                    if (!string.IsNullOrEmpty(value))
                        templates[key][LanguageIdConst.UZ_CYRL] = value;
                }

                if (ruIndex != -1)
                {
                    var value = worksheet.Cells[row, ruIndex].Text?.Trim();
                    if (!string.IsNullOrEmpty(value))
                        templates[key][LanguageIdConst.RU] = value;
                }

                if (enIndex != -1)
                {
                    var value = worksheet.Cells[row, enIndex].Text?.Trim();
                    if (!string.IsNullOrEmpty(value))
                        templates[key][LanguageIdConst.EN] = value;
                }
            }

            return templates;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing Excel translations");
            return new Dictionary<string, Dictionary<int, string>>();
        }
    }
    
    /// <summary>
    /// Simple CSV line parser (handles quoted values with commas)
    /// </summary>
    private string[] ParseCsvLine(string line)
    {
        var result = new List<string>();
        var current = "";
        var inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current.Trim());
                current = "";
            }
            else
            {
                current += c;
            }
        }

        result.Add(current.Trim());
        return result.ToArray();
    }

    private string FormatKeyWithData(string key, object data)
    {
        if (data == null)
        {
            return key;
        }

        var properties = data.GetType().GetProperties()
            .Select(p => $"{p.Name}: {p.GetValue(data)}")
            .ToArray();

        return properties.Length > 0
            ? $"{key} => {string.Join(", ", properties)}"
            : key;
    }
}

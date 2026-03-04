# Multi-Language Localization with Google Sheets & Stubble

This documentation explains how to use the `ILocalizationService` for multi-language error messages and UI strings using **Stubble** (Mustache templating) with **Google Sheets** as the translation source.

## Features

- ✅ **Multi-language support**: UZ_LATN, UZ_CYRL, RU, EN
- ✅ **Google Sheets integration**: Manage translations online without redeploying
- ✅ **Stubble (Mustache) templates**: Dynamic placeholders like `{{entityName}}`, `{{id}}`
- ✅ **Automatic fallback**: Uses embedded translations if Google Sheets is unavailable
- ✅ **Memory caching**: Reduces API calls to Google Sheets
- ✅ **Auto-refresh**: Optional automatic reload of translations
- ✅ **Current user language**: Automatically uses authenticated user's language preference

---

## Setup Guide

### 1. Create Google Sheet

Create a Google Sheet with this **exact** structure:

**IMPORTANT Requirements:**
- ✅ First row MUST contain headers: `Key`, `UZ_LATN`, `UZ_CYRL`, `RU`, `EN` (case-sensitive)
- ✅ Header names must match exactly (no extra spaces, no variations)
- ✅ The worksheet should be named "Translations", "Translation", or "Localization" (or contain a "Key" column)
- ✅ Data starts from row 2 (row 1 is the header)

| Key | UZ_LATN | UZ_CYRL | RU | EN |
|-----|---------|---------|----|----|
| CANNOT_CHANGE_STATUS | {{entityName}} holatini o'zgartirib bo'lmaydi | {{entityName}} ҳолатини ўзгартириб бўлмайди | Невозможно изменить статус документа {{entityName}} | Cannot change {{entityName}} status |
| DOCUMENT_NOT_FOUND | {{entityName}} topilmadi{{#id}}. ID: {{id}}{{/id}} | {{entityName}} топилмади{{#id}}. ID: {{id}}{{/id}} | {{entityName}} не найден{{#id}}. ID: {{id}}{{/id}} | {{entityName}} not found{{#id}}. ID: {{id}}{{/id}} |
| NOT_FOUND_OR_NOT_BELONGS | {{entityName}} topilmadi yoki tashkilotga tegishli emas{{#id}}! ID: {{id}}{{/id}} | {{entityName}} топилмади ёки ташкилотга тегишли эмас{{#id}}! ID: {{id}}{{/id}} | {{entityName}} не найден или не принадлежит организации{{#id}}! ID: {{id}}{{/id}} | {{entityName}} not found or does not belong to organization{{#id}}! ID: {{id}}{{/id}} |
| CANNOT_EDIT_DUE_TO_STATUS | {{entityName}}ni tahrirlash mumkin emas{{#currentStatusId}}. Joriy holat: {{currentStatusId}}{{/currentStatusId}} | {{entityName}}ни таҳрирлаш мумкин эмас{{#currentStatusId}}. Жорий ҳолат: {{currentStatusId}}{{/currentStatusId}} | Невозможно редактировать {{entityName}}{{#currentStatusId}}. Текущий статус: {{currentStatusId}}{{/currentStatusId}} | Cannot edit {{entityName}}{{#currentStatusId}}. Current status: {{currentStatusId}}{{/currentStatusId}} |

**Worksheet Detection Logic:**
The service will look for worksheets in this priority order:
1. Sheet named "Translations", "Translation", or "Localization" (case-insensitive)
2. First sheet that contains a "Key" column in the header row
3. First sheet in the workbook (with warning)

**Google Sheets Example:**
https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/edit

### 2. Choose Format: CSV or Excel

**IMPORTANT**: If your organization requires a commercial EPPlus license, use CSV format instead of Excel, or configure the license in your application.

**Option A: CSV Format (Recommended - No License Required)**

1. Open your Google Sheet
2. Go to **File → Share → Publish to web**
3. Select **Sheet name** and **CSV** format
4. Click **Publish**
5. Copy the CSV export URL:
   ```
   https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/export?format=csv&gid=0
   ```

**Option B: Excel Format**

1. Open your Google Sheet
2. Go to **File → Share → Publish to web**
3. Select **Entire Document** and **Excel** format
4. Click **Publish**
5. Copy the Excel export URL:
   ```
   https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/export?format=xlsx
   ```

### 3. Configure appsettings.json

Add this configuration to your service's `appsettings.json`:

**For CSV format:**
```json
{
  "Localization": {
    "GoogleSheetsUrl": "https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/export?format=csv&gid=0",
    "GoogleSheetsFormat": "csv",
    "EnableAutoRefresh": false,
    "AutoRefreshIntervalMinutes": 60,
    "CacheDurationMinutes": 30
  }
}
```

**For Excel format:**
```json
{
  "Localization": {
    "GoogleSheetsUrl": "https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/export?format=xlsx",
    "GoogleSheetsFormat": "xlsx",
    "EnableAutoRefresh": false,
    "AutoRefreshIntervalMinutes": 60,
    "CacheDurationMinutes": 30
  }
}
```

**Configuration Options:**

| Option | Description | Default |
|--------|-------------|---------|
| `GoogleSheetsUrl` | Export URL from Google Sheets (CSV or Excel) | `null` |
| `GoogleSheetsFormat` | Format of the export: `"csv"` or `"xlsx"` | `"csv"` |
| `EnableAutoRefresh` | Automatically refresh translations periodically | `false` |
| `AutoRefreshIntervalMinutes` | How often to refresh (if enabled) | `60` minutes |
| `CacheDurationMinutes` | How long to cache translations in memory | `30` minutes |

### 4. Register Service in DependencyInjection.cs

In your service's `Infrastructure/DependencyInjection.cs`:

```csharp
using Erp.Core.Service.Infrastructure.Localization;

public static IServiceCollection ConfigureHrmInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
{
    // ... existing registrations ...

    // Register LocalizationService
    services.AddLocalizationService(configuration);

    return services;
}
```

---

## Usage Examples

### Example 1: Basic Usage in Command Handler

```csharp
using Erp.Core.Service.Application.Localization;
using MediatR;
using WEBASE.Standard.AppError;

public class AppointEmployeeUpdateCommandHandler : IRequestHandler<AppointEmployeeUpdateCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IAuthService _authService;
    private readonly ILocalizationService _localization; // ✅ Inject

    public AppointEmployeeUpdateCommandHandler(
        IApplicationDbContext context,
        IAuthService authService,
        ILocalizationService localization) // ✅ Inject
    {
        _context = context;
        _authService = authService;
        _localization = localization;
    }

    public async Task<int> Handle(AppointEmployeeUpdateCommand request, CancellationToken ct)
    {
        var entity = await _context.AppointEmployee.FindAsync(request.Id);

        if (entity == null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    // ✅ Multi-language error message
                    ErrorMessage = _localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new
                    {
                        entityName = "Ishga tayinlash buyrug'i",
                        id = request.Id
                    }),
                    Key = "AppointEmployee"
                });

        // Status validation
        if (!StatusIdConst.CanApplyStatus(entity.StatusId, StatusIdConst.MODIFIED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    // ✅ Multi-language with Stubble template
                    ErrorMessage = _localization.GetLocalizedString("CANNOT_CHANGE_STATUS", new
                    {
                        entityName = "Hujjat"
                    }),
                    Key = "AppointEmployee"
                });

        // ... rest of handler logic
    }
}
```

**Output (depending on user's language):**
- **UZ_LATN**: "Hujjat holatini o'zgartirib bo'lmaydi"
- **UZ_CYRL**: "Ҳужжат ҳолатини ўзгартириб бўлмайди"
- **RU**: "Невозможно изменить статус документа Hujjat"
- **EN**: "Cannot change Hujjat status"

---

### Example 2: With Conditional Placeholders (Mustache Sections)

```csharp
// With ID
_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new
{
    entityName = "Shtatlar jadvali",
    id = 123  // ✅ Shows: "ID: 123"
});

// Without ID
_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new
{
    entityName = "Shtatlar jadvali"
    // id is not provided, so "ID: ..." section is hidden
});
```

**Mustache Template Syntax:**
```mustache
{{entityName}} topilmadi{{#id}}. ID: {{id}}{{/id}}
```

- `{{entityName}}` - Always rendered
- `{{#id}}...{{/id}}` - Only rendered if `id` has a value

---

### Example 3: FluentValidation with Localization

```csharp
using Erp.Core.Service.Application.Localization;
using FluentValidation;

public class AppointEmployeeUpdateCommandValidator : AbstractValidator<AppointEmployeeUpdateCommand>
{
    public AppointEmployeeUpdateCommandValidator(ILocalizationService localization)
    {
        RuleFor(x => x.DocNumber)
            .NotEmpty()
            .WithMessage(localization.GetLocalizedString("FIELD_REQUIRED", new { fieldName = "Hujjat raqami" }));

        RuleFor(x => x.DocNumber)
            .MaximumLength(50)
            .WithMessage(localization.GetLocalizedString("FIELD_MAX_LENGTH", new
            {
                fieldName = "Hujjat raqami",
                maxLength = 50
            }));
    }
}
```

---

### Example 4: Refresh Translations Endpoint (Optional)

Create an admin endpoint to manually refresh translations from Google Sheets:

```csharp
using Erp.Core.Service.Application.Localization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/admin/[controller]")]
public class LocalizationController : ControllerBase
{
    private readonly ILocalizationService _localization;

    public LocalizationController(ILocalizationService localization)
    {
        _localization = localization;
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTranslations()
    {
        await _localization.RefreshTranslationsAsync();
        return Ok(new { message = "Translations refreshed successfully" });
    }
}
```

**Usage:**
```bash
POST /api/admin/localization/refresh
```

---

## Stubble (Mustache) Template Syntax

### Variables

```mustache
{{entityName}} - Simple variable substitution
```

**Example:**
```csharp
_localization.GetLocalizedString("CANNOT_CHANGE_STATUS", new { entityName = "Hujjat" })
// Output: "Hujjat holatini o'zgartirib bo'lmaydi"
```

### Sections (Conditionals)

```mustache
{{#id}}ID: {{id}}{{/id}} - Only rendered if 'id' has a value
```

**Example:**
```csharp
// With id
_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new { entityName = "Hujjat", id = 123 })
// Output: "Hujjat topilmadi. ID: 123"

// Without id
_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new { entityName = "Hujjat" })
// Output: "Hujjat topilmadi"
```

### Inverted Sections

```mustache
{{^operation}}Default message{{/operation}} - Rendered only if 'operation' is NOT provided
```

**Example:**
```csharp
// Without operation
_localization.GetLocalizedString("OPERATION_FORBIDDEN")
// Output: "Ushbu amaliyotni bajarish taqiqlangan"

// With operation
_localization.GetLocalizedString("OPERATION_FORBIDDEN", new { operation = "O'chirish" })
// Output: "O'chirish taqiqlangan"
```

---

## Common Translation Keys

| Key | Description | Placeholders |
|-----|-------------|--------------|
| `CANNOT_CHANGE_STATUS` | Status cannot be changed | `entityName` |
| `DOCUMENT_NOT_FOUND` | Document not found | `entityName`, `id` (optional) |
| `NOT_FOUND_OR_NOT_BELONGS` | Not found or doesn't belong to org | `entityName`, `id` (optional) |
| `CANNOT_EDIT_DUE_TO_STATUS` | Cannot edit due to current status | `entityName`, `currentStatusId` (optional) |
| `CANNOT_DELETE_DUE_TO_STATUS` | Cannot delete due to current status | `entityName`, `currentStatusId` (optional) |
| `FIELD_REQUIRED` | Field is required | `fieldName` |
| `FIELD_MAX_LENGTH` | Field exceeds max length | `fieldName`, `maxLength` |
| `TEMPLATE_NOT_FOUND` | Excel/PDF template not found | None |
| `DUPLICATE_ENTRY` | Duplicate entry exists | `fieldName` |
| `OPERATION_FORBIDDEN` | Operation is forbidden | `operation` (optional) |
| `ACCESS_DENIED` | Access denied | None |
| `INVALID_DATE` | Invalid date | `fieldName` |
| `INVALID_DATE_RANGE` | Invalid date range | `startFieldName`, `endFieldName` |

---

## How Language is Determined

The service automatically uses the current user's language preference via `ICultureHelper`:

1. **HTTP Header `Lang`**: If present, uses this language (e.g., `uz-latn`, `ru`, `en`)
2. **Authenticated User's Language**: From `_authService.User.LanguageCode`
3. **Default Language**: Falls back to `UZ_LATN`

**Example HTTP Request:**
```http
GET /api/appoint-employee/123
Lang: ru
```

This will return error messages in Russian.

---

## Troubleshooting

### Translations not loading from Google Sheets

1. **Check URL Format**: The most common issue is using the wrong URL format
   - ❌ **WRONG**: `https://docs.google.com/spreadsheets/d/SHEET_ID/edit?gid=0#gid=0` (edit URL)
   - ✅ **CORRECT**: `https://docs.google.com/spreadsheets/d/SHEET_ID/export?format=xlsx&gid=0` (export URL)
   - The URL must use `/export?format=xlsx` or `/export?format=csv`, NOT `/edit`

2. **Check Logs**: Look for these error messages:
   - "Downloaded content appears to be HTML, not Excel" - indicates wrong URL format
   - "Failed to download Excel from Google Sheets" - indicates network or permission issue
   - "The file is not a valid Package file" - indicates downloaded HTML instead of Excel
   - "Please set the ExcelPackage.LicenseContext property" - EPPlus license issue (already configured in code)

3. **Verify Sheet Permissions**: Ensure the Google Sheet is published to web:
   - Go to **File → Share → Publish to web**
   - Select the appropriate sheet and format (CSV or Excel)
   - Click **Publish** and use the generated export URL

4. **Test Manually**: Open the export URL in a browser:
   - For Excel: Should download an `.xlsx` file
   - For CSV: Should display comma-separated text

5. **Check Worksheet Structure**: If you see "Excel header missing 'Key' column":
   - Verify your Google Sheet has the correct header row: `Key`, `UZ_LATN`, `UZ_CYRL`, `RU`, `EN`
   - Check that headers are in **row 1** (not row 2 or later)
   - Ensure header names match exactly (case-sensitive, no extra spaces)
   - Look at the logs to see what columns were found and what the first 3 rows contain
   - Consider renaming your worksheet to "Translations" or "Localization"
   - If you have multiple sheets, make sure the correct one is being used (check logs for worksheet names)

### Falling back to embedded translations

If Google Sheets is unavailable, the service automatically uses embedded fallback translations. Check:
- `UseFallbackTranslations` is `true` in `appsettings.json`
- Logs show: "Using fallback embedded translations"

### Wrong language displayed

1. **Check HTTP Header**: Ensure `Lang` header is set correctly
2. **Check user language**: Verify authenticated user's `LanguageCode` in database
3. **Check language ID mapping**: Ensure your Google Sheet columns match `LanguageIdConst` values

### Cache issues

If translations don't update after changing Google Sheets:
1. Wait for cache to expire (`CacheDurationMinutes`)
2. Call the refresh endpoint: `POST /api/admin/localization/refresh`
3. Restart the service

---

## Best Practices

### 1. Use Descriptive Entity Names

```csharp
// ✅ Good
_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new
{
    entityName = "Ishga tayinlash buyrug'i"
});

// ❌ Avoid
_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new
{
    entityName = "Document"
});
```

### 2. Provide Optional Fields Conditionally

```csharp
// ✅ Good - only include ID if available
var data = new { entityName = "Hujjat" };
if (entityId.HasValue)
    data = new { entityName = "Hujjat", id = entityId.Value };

_localization.GetLocalizedString("DOCUMENT_NOT_FOUND", data);
```

### 3. Keep Translation Keys Consistent

Use `UPPER_SNAKE_CASE` for keys:
- ✅ `CANNOT_CHANGE_STATUS`
- ✅ `DOCUMENT_NOT_FOUND`
- ❌ `cannotChangeStatus`
- ❌ `document-not-found`

### 4. Test All Languages

Before deploying, test with different `Lang` header values:
```bash
curl -H "Lang: uz-latn" http://localhost:5005/api/test
curl -H "Lang: uz-cyrl" http://localhost:5005/api/test
curl -H "Lang: ru" http://localhost:5005/api/test
curl -H "Lang: en" http://localhost:5005/api/test
```

### 5. Use Fallback Translations for Critical Errors

Always set `UseFallbackTranslations: true` in production to ensure error messages are always displayed, even if Google Sheets is unavailable.

---

## Migration from Hardcoded Strings

### Before (Hardcoded)

```csharp
if (!StatusIdConst.CanApplyStatus(entity.StatusId, StatusIdConst.MODIFIED))
    throw new WbClientException()
        .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
        .WithErrors(new WbFailure
        {
            ErrorMessage = "Hujjat holatini o'zgartirib bo'lmaydi", // ❌ Hardcoded
            Key = "AppointEmployee"
        });
```

### After (Localized)

```csharp
if (!StatusIdConst.CanApplyStatus(entity.StatusId, StatusIdConst.MODIFIED))
    throw new WbClientException()
        .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
        .WithErrors(new WbFailure
        {
            ErrorMessage = _localization.GetLocalizedString("CANNOT_CHANGE_STATUS", new
            {
                entityName = "Hujjat"
            }), // ✅ Multi-language
            Key = "AppointEmployee"
        });
```

---

## Google Sheets Template

Download this template to get started quickly:

**Columns:**
- `Key` - Translation key (e.g., CANNOT_CHANGE_STATUS)
- `UZ_LATN` - Uzbek Latin text
- `UZ_CYRL` - Uzbek Cyrillic text
- `RU` - Russian text
- `EN` - English text

**Example Rows:**

```csv
Key,UZ_LATN,UZ_CYRL,RU,EN
CANNOT_CHANGE_STATUS,{{entityName}} holatini o'zgartirib bo'lmaydi,{{entityName}} ҳолатини ўзгартириб бўлмайди,Невозможно изменить статус документа {{entityName}},Cannot change {{entityName}} status
DOCUMENT_NOT_FOUND,{{entityName}} topilmadi{{#id}}. ID: {{id}}{{/id}},{{entityName}} топилмади{{#id}}. ID: {{id}}{{/id}},{{entityName}} не найден{{#id}}. ID: {{id}}{{/id}},{{entityName}} not found{{#id}}. ID: {{id}}{{/id}}
```

---

## EPPlus License Information

This service uses **EPPlus** for Excel file processing. EPPlus is configured to use `LicenseContext.NonCommercial`:

```csharp
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
```

**License Options:**
- **NonCommercial**: Free for non-commercial use, internal business applications, and educational purposes
- **Commercial**: Requires a paid license for commercial software distribution

**Important Notes:**
- The `NonCommercial` license is suitable for internal ERP systems used within your organization
- If you're distributing this software commercially, you need to purchase an EPPlus commercial license
- Alternatively, use **CSV format** instead of Excel to avoid EPPlus licensing requirements entirely

For more information: https://epplussoftware.com/developers/licenseexception

---

## References

- **Stubble Documentation**: https://github.com/StubbleOrg/Stubble
- **Mustache Syntax**: https://mustache.github.io/mustache.5.html
- **Google Sheets API**: https://developers.google.com/sheets/api
- **EPPlus License**: https://epplussoftware.com/developers/licenseexception

---

## Support

For questions or issues, contact the WEBASE development team or refer to the project's code review documentation in `code-review/`.

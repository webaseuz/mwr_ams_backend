# Localization Service - Usage Guide

## Overview

The `ILocalizationService` provides multi-language support with Google Sheets integration and Mustache template syntax. It supports both direct method calls and a fluent API for maximum flexibility.

## Features

- ✅ Multi-language support (UZ_LATN, UZ_CYRL, RU, EN)
- ✅ Mustache template syntax for dynamic content
- ✅ Google Sheets integration (CSV and Excel formats)
- ✅ Memory caching with configurable duration
- ✅ Fluent API for flexible usage
- ✅ Fallback mechanism (Requested language → UZ_LATN → First available → Key)

## Configuration

### appsettings.json

```json
{
  "Localization": {
    "GoogleSheetsUrl": "https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/export?format=csv",
    "GoogleSheetsFormat": "csv",
    "CacheDurationMinutes": 60
  }
}
```

### Google Sheets Format

Your Google Sheet should have the following structure:

| Key | UZ_LATN | UZ_CYRL | RU | EN |
|-----|---------|---------|----|----|
| WELCOME_MESSAGE | Xush kelibsiz, {{userName}}! | Хуш келибсиз, {{userName}}! | Добро пожаловать, {{userName}}! | Welcome, {{userName}}! |
| CANNOT_CHANGE_STATUS | {{entityName}} holatini o'zgartirib bo'lmaydi | {{entityName}} ҳолатини ўзгартириб бўлмайди | Невозможно изменить статус документа {{entityName}} | Cannot change {{entityName}} status |
| DOCUMENT_NOT_FOUND | Hujjat topilmadi. ID: {{documentId}} | Ҳужжат топилмади. ID: {{documentId}} | Документ не найден. ID: {{documentId}} | Document not found. ID: {{documentId}} |

## Usage Examples

### Method 1: Direct Method Calls

```csharp
public class MyHandler
{
    private readonly ILocalizationService _localization;

    public MyHandler(ILocalizationService localization)
    {
        _localization = localization;
    }

    public void Example1_Simple()
    {
        // Uses current user's culture
        string message = _localization.GetString("WELCOME_MESSAGE");
        // Output (if user's culture is UZ_LATN): "Xush kelibsiz!"
    }

    public void Example2_WithData()
    {
        // With template data
        string message = _localization.GetString(
            "WELCOME_MESSAGE",
            new { userName = "Alisher" }
        );
        // Output: "Xush kelibsiz, Alisher!"
    }

    public void Example3_SpecificCulture()
    {
        // Specific culture
        string message = _localization.GetString(
            LanguageIdConst.RUSSIAN,
            "WELCOME_MESSAGE",
            new { userName = "Алишер" }
        );
        // Output: "Добро пожаловать, Алишер!"
    }
}
```

### Method 2: Fluent API (Recommended)

```csharp
public class MyHandler
{
    private readonly ILocalizationBuilder _localization;

    public MyHandler(ILocalizationBuilder localization)
    {
        _localization = localization;
    }

    public void Example1_Simple()
    {
        // Simplest form - uses current user's culture
        string message = _localization.For("WELCOME_MESSAGE").Build();
    }

    public void Example2_WithData()
    {
        // With template data interpolation
        string message = _localization.For("WELCOME_MESSAGE")
            .WithData(new { userName = "Alisher" })
            .Build();
        // Output: "Xush kelibsiz, Alisher!"
    }

    public void Example3_SpecificCulture()
    {
        // With specific culture
        string message = _localization.For("WELCOME_MESSAGE")
            .WithCulture(LanguageIdConst.RUSSIAN)
            .WithData(new { userName = "Алишер" })
            .Build();
        // Output: "Добро пожаловать, Алишер!"
    }

    public void Example4_WithFallback()
    {
        // With fallback for optional keys
        string message = _localization.For("OPTIONAL_NOTIFICATION")
            .WithFallback("Default notification text")
            .Build();
        // Returns fallback if key not found
    }

    public void Example5_ErrorMessage()
    {
        // Complex example: Error message in exception
        throw new WbClientException()
            .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
            .WithErrors(new WbFailure
            {
                ErrorMessage = _localization.For("CANNOT_CHANGE_STATUS")
                    .WithData(new { entityName = "Staffing" })
                    .Build(),
                Key = "InvalidStatusTransition"
            });
    }

    public void Example6_ChainedConfiguration()
    {
        // All options together
        string message = _localization.For("DOCUMENT_NOT_FOUND")
            .WithCulture(LanguageIdConst.UZBEK_CYRILLIC)
            .WithData(new { documentId = 12345 })
            .WithFallback("Document not found")
            .Build();
        // Output: "Ҳужжат топилмади. ID: 12345"
    }
}
```

### Method 3: Using in Command Handlers

```csharp
public class StaffingUpdateCommandHandler : IRequestHandler<StaffingUpdateCommand, WbHaveId<long>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMainAuthService _authService;
    private readonly ILocalizationBuilder _localization;

    public StaffingUpdateCommandHandler(
        IApplicationDbContext dbContext,
        IMainAuthService authService,
        ILocalizationBuilder localization)
    {
        _dbContext = dbContext;
        _authService = authService;
        _localization = localization;
    }

    public async Task<WbHaveId<long>> Handle(StaffingUpdateCommand request, CancellationToken ct)
    {
        var entity = await _dbContext.Staffings
            .FirstOrDefaultAsync(x => x.Id == request.Id
                && x.OrganizationId == _authService.CurrentOrganizationId, ct);

        if (entity == null)
            throw new WbNotFoundException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    ErrorMessage = _localization.For("STAFFING_NOT_FOUND")
                        .WithData(new
                        {
                            Id = request.Id,
                            DocNumber = request.DocNumber
                        })
                        .Build(),
                    Key = "Staffing"
                });

        // Validate status transition
        if (!StatusIdConst.CanApplyStatus(entity.StatusId, StatusIdConst.MODIFIED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    ErrorMessage = _localization.For("CANNOT_CHANGE_STATUS")
                        .WithData(new
                        {
                            entityName = "Staffing",
                            currentStatus = entity.StatusId
                        })
                        .Build(),
                    Key = "Staffing"
                });

        // ... rest of handler logic
    }
}
```

### Method 4: Using in Validators

```csharp
public class StaffingCreateCommandValidator : AbstractValidator<StaffingCreateCommand>
{
    private readonly ILocalizationBuilder _localization;

    public StaffingCreateCommandValidator(ILocalizationBuilder localization)
    {
        _localization = localization;

        RuleFor(x => x.DocNumber)
            .NotEmpty()
            .WithMessage(_ => _localization.For("VALIDATION_DOC_NUMBER_REQUIRED").Build())
            .MaximumLength(30)
            .WithMessage(_ => _localization.For("VALIDATION_DOC_NUMBER_MAX_LENGTH")
                .WithData(new { maxLength = 30 })
                .Build());

        RuleFor(x => x.Positions)
            .NotEmpty()
            .WithMessage(_ => _localization.For("VALIDATION_POSITIONS_REQUIRED").Build());

        RuleFor(x => x.FinanceYear)
            .GreaterThan(2000)
            .WithMessage(_ => _localization.For("VALIDATION_YEAR_MIN")
                .WithData(new { minYear = 2000 })
                .Build())
            .LessThanOrEqualTo(2100)
            .WithMessage(_ => _localization.For("VALIDATION_YEAR_MAX")
                .WithData(new { maxYear = 2100 })
                .Build());
    }
}
```

## Mustache Template Syntax

The localization service uses Stubble (Mustache) for template rendering with **case-insensitive** variable lookup.

### Simple Variables
```
Template: "Hello, {{userName}}!"
Data: { userName: "John" }  // or { USERNAME: "John" } or { username: "John" }
Output: "Hello, John!"

Note: Property names are case-insensitive
```

### Nested Objects
```
Template: "User: {{user.name}}, Email: {{user.email}}"
Data: { user: { name: "John", email: "john@example.com" } }
Output: "User: John, Email: john@example.com"
```

### Conditionals
```
Template: "{{#isActive}}Active{{/isActive}}{{^isActive}}Inactive{{/isActive}}"
Data: { isActive: true }
Output: "Active"
```

### Lists
```
Template: "Items: {{#items}}{{name}}, {{/items}}"
Data: { items: [{ name: "A" }, { name: "B" }] }
Output: "Items: A, B, "
```

## Administrative Operations

### Refresh Translations

```csharp
public class TranslationController : ControllerBase
{
    private readonly ILocalizationService _localization;

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTranslations(CancellationToken ct)
    {
        await _localization.RefreshTranslationsAsync(ct);
        return Ok(new { message = "Translations refreshed successfully" });
    }
}
```

## Best Practices

1. **Use Fluent API for New Code**: The `.For()` fluent API is cleaner and more readable
2. **Thread-safe and Request-safe**: Each call to `.For()` creates a new builder instance, preventing state pollution across multiple calls
   ```csharp
   // Safe - each For() creates a new instance
   var msg1 = _localization.For("KEY1").WithData(new { name = "Test1" }).Build();
   var msg2 = _localization.For("KEY2").WithData(new { name = "Test2" }).Build();
   // msg1 and msg2 are completely isolated
   ```
3. **Always provide template data**: Even empty objects work: `.WithData(new { })`
4. **Use fallbacks for optional messages**: Prevents key-as-message returns
5. **Keep translation keys in constants**: Create a `LocalizationKeys` class
6. **Test with different cultures**: Ensure all cultures have translations
7. **Cache duration**: Set appropriate cache duration in appsettings.json
8. **Use descriptive keys**: `STAFFING_NOT_FOUND` > `ERROR_1`

## Translation Keys Constants (Recommended Pattern)

```csharp
public static class LocalizationKeys
{
    // Document operations
    public const string DOCUMENT_NOT_FOUND = "DOCUMENT_NOT_FOUND";
    public const string CANNOT_CHANGE_STATUS = "CANNOT_CHANGE_STATUS";
    public const string DOCUMENT_SAVED = "DOCUMENT_SAVED";

    // Validation messages
    public const string VALIDATION_DOC_NUMBER_REQUIRED = "VALIDATION_DOC_NUMBER_REQUIRED";
    public const string VALIDATION_POSITIONS_REQUIRED = "VALIDATION_POSITIONS_REQUIRED";

    // Welcome messages
    public const string WELCOME_MESSAGE = "WELCOME_MESSAGE";
    public const string GOODBYE_MESSAGE = "GOODBYE_MESSAGE";
}

// Usage (inject ILocalizationBuilder):
private readonly ILocalizationBuilder _localization;

var message = _localization.For(LocalizationKeys.WELCOME_MESSAGE)
    .WithData(new { userName = user.Name })
    .Build();
```

## Troubleshooting

### Translation key not found
- Check Google Sheets has the key in the "Key" column
- Verify cache is refreshed (call `RefreshTranslationsAsync()`)
- Check logs for loading errors

### Template data not interpolating
- Property names are case-insensitive: `{{userName}}` = `{{username}}` = `{{USERNAME}}`
- Verify Mustache syntax: `{{propertyName}}`
- Check data object is not null

### Wrong culture displayed
- Verify `ICultureHelper.CurrentCulture.Id` returns correct culture ID
- Check Google Sheets has translation for that culture
- Review fallback chain in logs

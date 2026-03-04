# Example: Converting Hardcoded Error Messages to Multi-Language

## Before (Hardcoded Uzbek)

```csharp
// Status tekshiruvi
if (!StatusIdConst.CanApplyStatus(entity.StatusId, StatusIdConst.MODIFIED))
    throw new WbClientException()
        .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
        .WithErrors(new WbFailure
        {
            ErrorMessage = "Hujjat holatini o'zgartirib bo'lmaydi", // ❌ Only Uzbek
            Key = "AppointEmployee"
        });
```

---

## After (Multi-Language with Stubble)

### Step 1: Inject ILocalizationService

```csharp
using Erp.Core.Service.Application.Localization;

public class AppointEmployeeUpdateCommandHandler : IRequestHandler<AppointEmployeeUpdateCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IAuthService _authService;
    private readonly ILocalizationService _localization; // ✅ Add this

    public AppointEmployeeUpdateCommandHandler(
        IApplicationDbContext context,
        IAuthService authService,
        ILocalizationService localization) // ✅ Add this
    {
        _context = context;
        _authService = authService;
        _localization = localization;
    }

    // ... rest of code
}
```

### Step 2: Replace Hardcoded String

```csharp
// Status tekshiruvi
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
```

---

## 🌍 What Happens Now

When a user makes a request with different languages:

### Request with Russian
```http
POST /api/appoint-employee/update
Lang: ru
```

**Error Response:**
```json
{
  "errors": [
    {
      "errorMessage": "Невозможно изменить статус документа Hujjat",
      "key": "AppointEmployee"
    }
  ]
}
```

### Request with Uzbek (Cyrillic)
```http
POST /api/appoint-employee/update
Lang: uz-cyrl
```

**Error Response:**
```json
{
  "errors": [
    {
      "errorMessage": "Ҳужжат ҳолатини ўзгартириб бўлмайди",
      "key": "AppointEmployee"
    }
  ]
}
```

### Request with English
```http
POST /api/appoint-employee/update
Lang: en
```

**Error Response:**
```json
{
  "errors": [
    {
      "errorMessage": "Cannot change Hujjat status",
      "key": "AppointEmployee"
    }
  ]
}
```

### Request without Lang header (uses user's preferred language)
```http
POST /api/appoint-employee/update
Authorization: Bearer {token}
```

**Error Response** (if user's `LanguageCode` is `uz-latn`):
```json
{
  "errors": [
    {
      "errorMessage": "Hujjat holatini o'zgartirib bo'lmaydi",
      "key": "AppointEmployee"
    }
  ]
}
```

---

## 🎨 More Examples with Dynamic Data

### Example 1: Include Entity ID

```csharp
var entity = await _context.AppointEmployee.FindAsync(request.Id);

if (entity == null)
    throw new WbNotFoundException()
        .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
        .WithErrors(new WbFailure
        {
            // ✅ Shows ID in error message
            ErrorMessage = _localization.GetLocalizedString("DOCUMENT_NOT_FOUND", new
            {
                entityName = "Ishga tayinlash buyrug'i",
                id = request.Id // Shows: "ID: 123"
            }),
            Key = "AppointEmployee"
        });
```

**Output (UZ_LATN):** `"Ishga tayinlash buyrug'i topilmadi. ID: 123"`

**Output (RU):** `"Ishga tayinlash buyrug'и не найден. ID: 123"`

### Example 2: Organization Check

```csharp
var entity = await _context.AppointEmployee
    .FirstOrDefaultAsync(x => x.Id == request.Id && x.OrganizationId == _authService.CurrentOrganizationId);

if (entity == null)
    throw new WbClientException()
        .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
        .WithErrors(new WbFailure
        {
            // ✅ Shows "not found or doesn't belong to organization"
            ErrorMessage = _localization.GetLocalizedString("NOT_FOUND_OR_NOT_BELONGS", new
            {
                entityName = "Ishga tayinlash buyrug'i",
                id = request.Id
            }),
            Key = "AppointEmployee"
        });
```

**Output (UZ_LATN):** `"Ishga tayinlash buyrug'i topilmadi yoki tashkilotga tegishli emas! ID: 123"`

**Output (EN):** `"Ishga tayinlash buyrug'i not found or does not belong to organization! ID: 123"`

### Example 3: Status-Specific Error

```csharp
if (!StatusIdConst.CanApplyStatus(entity.StatusId, StatusIdConst.MODIFIED))
    throw new WbClientException()
        .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
        .WithErrors(new WbFailure
        {
            // ✅ Shows current status ID
            ErrorMessage = _localization.GetLocalizedString("CANNOT_EDIT_DUE_TO_STATUS", new
            {
                entityName = "Ishga tayinlash buyrug'i",
                currentStatusId = entity.StatusId // Shows current status
            }),
            Key = "AppointEmployee"
        });
```

**Output (UZ_LATN):** `"Ishga tayinlash buyrug'ini tahrirlash mumkin emas. Joriy holat: 3"`

**Output (RU):** `"Невозможно редактировать Ishga tayinlash buyrug'i. Текущий статус: 3"`

---

## 🔄 Complete Handler Example

```csharp
using Erp.Core.Constants;
using Erp.Core.Security;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Standard.AppError;

public class AppointEmployeeUpdateCommandHandler : IRequestHandler<AppointEmployeeUpdateCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IAuthService _authService;
    private readonly ILocalizationService _localization;

    public AppointEmployeeUpdateCommandHandler(
        IApplicationDbContext context,
        IAuthService authService,
        ILocalizationService localization)
    {
        _context = context;
        _authService = authService;
        _localization = localization;
    }

    public async Task<int> Handle(AppointEmployeeUpdateCommand request, CancellationToken ct)
    {
        // Find entity
        var entity = await _context.AppointEmployee
            .FirstOrDefaultAsync(x => x.Id == request.Id
                && x.OrganizationId == _authService.CurrentOrganizationId, ct);

        // Check if exists and belongs to organization
        if (entity == null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    ErrorMessage = _localization.GetLocalizedString("NOT_FOUND_OR_NOT_BELONGS", new
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
                    ErrorMessage = _localization.GetLocalizedString("CANNOT_CHANGE_STATUS", new
                    {
                        entityName = "Ishga tayinlash buyrug'i"
                    }),
                    Key = "AppointEmployee"
                });

        // Update entity
        entity.DocNumber = request.DocNumber;
        entity.DocDate = request.DocDate;
        entity.StatusId = StatusIdConst.MODIFIED;
        // ... other updates

        await _context.SaveChangesAsync(ct);
        return entity.Id;
    }
}
```

---

## 📝 Google Sheets Setup for These Examples

Your Google Sheet should have these keys:

| Key | UZ_LATN | UZ_CYRL | RU | EN |
|-----|---------|---------|----|----|
| CANNOT_CHANGE_STATUS | {{entityName}} holatini o'zgartirib bo'lmaydi | {{entityName}} ҳолатини ўзгартириб бўлмайди | Невозможно изменить статус документа {{entityName}} | Cannot change {{entityName}} status |
| DOCUMENT_NOT_FOUND | {{entityName}} topilmadi{{#id}}. ID: {{id}}{{/id}} | {{entityName}} топилмади{{#id}}. ID: {{id}}{{/id}} | {{entityName}} не найден{{#id}}. ID: {{id}}{{/id}} | {{entityName}} not found{{#id}}. ID: {{id}}{{/id}} |
| NOT_FOUND_OR_NOT_BELONGS | {{entityName}} topilmadi yoki tashkilotga tegishli emas{{#id}}! ID: {{id}}{{/id}} | {{entityName}} топилмади ёки ташкилотга тегишли эмас{{#id}}! ID: {{id}}{{/id}} | {{entityName}} не найден или не принадлежит организации{{#id}}! ID: {{id}}{{/id}} | {{entityName}} not found or does not belong to organization{{#id}}! ID: {{id}}{{/id}} |
| CANNOT_EDIT_DUE_TO_STATUS | {{entityName}}ni tahrirlash mumkin emas{{#currentStatusId}}. Joriy holat: {{currentStatusId}}{{/currentStatusId}} | {{entityName}}ни таҳрирлаш мумкин эмас{{#currentStatusId}}. Жорий ҳолат: {{currentStatusId}}{{/currentStatusId}} | Невозможно редактировать {{entityName}}{{#currentStatusId}}. Текущий статус: {{currentStatusId}}{{/currentStatusId}} | Cannot edit {{entityName}}{{#currentStatusId}}. Current status: {{currentStatusId}}{{/currentStatusId}} |

---

## ✅ Benefits

1. **No Redeployment**: Update translations in Google Sheets without restarting services
2. **Automatic Language Detection**: Uses HTTP `Lang` header or user's preferred language
3. **Type-Safe**: Compile-time checking with Stubble templates
4. **Fallback Support**: Works even if Google Sheets is unavailable
5. **Cached**: Fast performance with in-memory caching
6. **Flexible**: Supports dynamic data with Mustache placeholders

---

## 🚀 Quick Migration Checklist

- [ ] Create Google Sheet with translations
- [ ] Publish sheet as CSV
- [ ] Add `Localization` section to `appsettings.json`
- [ ] Register `services.AddLocalizationService(configuration)` in DI
- [ ] Inject `ILocalizationService` in your handlers
- [ ] Replace hardcoded strings with `_localization.GetLocalizedString(...)`
- [ ] Test with different `Lang` header values
- [ ] Deploy! 🎉

# ERP CRUD Generator Prompt

## Ishlatish tartibi
1. Ushbu `.md` faylni Claude Code-ga path bilan ko'rsat
2. Database SQL scriptni tashla
3. Claude barcha savollarni beradi, so'ng kod yozadi

---

## CLAUDE uchun ko'rsatma

Sen ERP loyhasida SQL database script asosida to'liq CRUD kod generatsiya qiluvchi assistantsan.

### 1-QADAM: CLAUDE.md dan loyha ma'lumotlarini o'qi

Loyha ildiz papkasidagi `CLAUDE.md` faylini o'qi. U yerdan quyidagilarni toping:
- **DB scripts folder**: SQL script saqlanadigan papka (masalan: `mad_erp_backend/database/scripts/`)
- **Models project path**: DTOlar, Commands, Queries joyi
- **Application project path**: Handlers, Validators, Profiles joyi
- **Domain project path**: Entity class-lar joyi
- Boshqa loyha-spesifik konventsiyalar

Agar `CLAUDE.md` da bu yo'llar ko'rsatilmagan bo'lsa, foydalanuvchidan so'ra.

---

### 2-QADAM: SQL scriptni saqlash

SQL scriptni `CLAUDE.md` da ko'rsatilgan papkaga saqlash:

```
{db_scripts_folder}/{schema}/{table_name}.sql
```

Agar papka mavjud bo'lmasa, yaratish.

---

### 3-QADAM: SQL scriptni tahlil qilish

#### 3.1 — Jadval nomidan entity nomini aniqlash

```
snake_case → PascalCase
expense_battery   → ExpenseBattery
transport_model   → TransportModel
driver_penalty    → DriverPenalty
```

#### 3.2 — Schemadan kategoriyani aniqlash

| Schema / Belgi | Kategoriya | Papka |
|---|---|---|
| `info` | Info | `Info/{Entity}/` |
| `hl` yoki `public` (asosiy entity) | Hl | `Hl/{Entity}/` |
| `doc` yoki `status_id` kolumn bor | Doc | `Doc/{Entity}/` |
| `sys` | Sys | `Sys/{Entity}/` |
| `ref`, `enum`, yoki `_translate` jadvali bor | Enum | `Enum/{Entity}/` |
| `acc` | Acc | `Acc/{Entity}/` |
| `report` | Report | `Report/{Entity}/` |

#### 3.3 — Kolumnlardan xususiyatlarni aniqlash

```sql
-- Bu kolumnlarni entity property-ga aylantir:
id              → long Id (yoki int, script turiga qarab)
branch_id       → int BranchId
status_id       → int StatusId     ← Doc belgisi
state_id        → int StateId      ← Hl/Info belgisi
is_deleted      → bool IsDeleted   ← soft delete
created_by      → int? CreatedBy
modified_by     → int? LastModifiedBy   ← DB: modified_by, C#: LastModifiedBy
created_at      → DateTime CreatedAt
modified_at     → DateTime? ModifiedAt
doc_date        → DateTime DocDate
doc_number      → string DocNumber
```

#### 3.4 — FK kolumnlardan Include zanjirini aniqlash

```sql
branch_id  → .Include(x => x.Branch)
person_id  → .Include(x => x.Person)
status_id  → .Include(x => x.Status)
state_id   → .Include(x => x.State)
```

#### 3.5 — Tarjima jadvalini aniqlash

Agar `{table_name}_translate` jadvali mavjud bo'lsa:
- Bu entity **tarjimali** — `CultureProfile` (base class) ishlatiladi
- Handler-da `MapTo<BriefDto>(mapper, cultureHelper)` ishlatiladi

Aks holda:
- Oddiy `Profile` ishlatiladi
- Handler-da `mapper.Map<BriefDto>(entity)` ishlatiladi

---

### 4-QADAM: Foydalanuvchidan qo'shimcha ma'lumot so'rash

Tahlil natijasini foydalanuvchiga ko'rsat va quyidagi savollarni ber:

#### Barcha tiplarga:
```
Aniqladim:
  Entity: {EntityName}
  Kategoriya: {Category}
  Id turi: long / int
  Tarjima: bor / yo'q

Savollar:
1. Sub-kolleksiyalar bormi? (masalan: ExpenseBattery → ExpenseBatteryOil, ExpenseBatteryFile)
   Agar ha, ularning SQL scriptlarini ham bering.

2. Fayl yuklash kerakmi? (FileUpload / FileDownload)
   Agar ha, qaysi entity uchun? (asosiy, sub-kolleksiya?)
```

#### Faqat `Doc` uchun qo'shimcha:
```
3. Qaysi status operatsiyalar kerak?
   [ ] Accept   (CREATED → ACCEPTED)
   [ ] Cancel   (... → CANCELLED)
   [ ] Revoke   (ACCEPTED → CREATED/REVOKED)
   [ ] Send     (... → SENT)
   [ ] Reject   (... → REJECTED)
   [ ] Complete (... → COMPLETED)
   Boshqa: ___

4. GetById uchun to'liq Dto kerakmi? (barcha sub-kolleksiyalar bilan)
   Ha / Yo'q
```

Foydalanuvchi javob bergach, kod generatsiyaga o't.

---

### 5-QADAM: PREREKVIZITLAR — Kod yozishdan OLDIN tekshir

Quyidagilar mavjud ekanligini tekshir:

#### 5a — Domain entity
```
{DomainProject}/{Category}/{EntityName}.cs
```
Agar yo'q bo'lsa — CREATE qiling (yoki foydalanuvchidan so'rang).

Entity asosiy shakli:
```csharp
namespace {DomainNamespace};

public class {Entity}
{
    public long Id { get; set; }
    public int BranchId { get; set; }
    public int StatusId { get; set; }     // Doc uchun
    public int StateId { get; set; }      // Hl/Info uchun
    public bool IsDeleted { get; set; }
    public int? CreatedBy { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // Navigation properties:
    public virtual Branch Branch { get; set; }
    public virtual Status Status { get; set; }   // Doc uchun

    // Sub-kolleksiya:
    public virtual ICollection<{Entity}{Sub}> {Subs} { get; set; } = [];
}
```

#### 5b — IApplicationDbContext-da DbSet bor-yo'qligini tekshir
Agar yo'q bo'lsa — qo'shish kerak:
```csharp
DbSet<{Entity}> {Entities} { get; }
```

#### 5c — `StatusIdConst.Can{Entity}Status()` mavjudligini tekshir (Doc uchun)
`StatusIdConst` yoki shunga o'xshash constant faylda:
```csharp
public static bool Can{Entity}Status(int currentStatus, int targetStatus)
{
    return (currentStatus, targetStatus) switch
    {
        (CREATED, ACCEPTED) => true,
        (CREATED, CANCELLED) => true,
        (ACCEPTED, CREATED) => true,    // revoke
        (CREATED, DELETED) => true,
        (CANCELLED, DELETED) => true,
        _ => false
    };
}
```
Agar bu metod yo'q bo'lsa — foydalanuvchiga ayt va qo'shishni so'ra.

#### 5d — `FileStorageConst.{ENTITY}_FILE` mavjudligini tekshir (fayl bo'lsa)
Agar yo'q bo'lsa — foydalanuvchidan so'ra yoki constant faylga qo'sh:
```csharp
public const string {ENTITY}_FILE = "{entity_file}";
```

---

### 6-QADAM: KOD GENERATSIYA

---

## MODELS PROJECT — Fayl tuzilmasi va pattern-lar

### 5.1 — Commands

#### `{Entity}CreateCommand.cs`
```csharp
using MediatR;
using WEBASE;

namespace {ModelsNamespace};

public class {Entity}CreateCommand : IRequest<WbHaveId<long>>
{
    // SQL script kolumnlaridan (id, created_at, modified_at, status_id, state_id OLIB TASHLANADI)
    public int BranchId { get; set; }
    public DateTime DocDate { get; set; }
    public string DocNumber { get; set; }
    // ... boshqa maydonlar

    // Sub-kolleksiya bo'lsa:
    public List<{Entity}{Sub}CreateCommand> {Subs} { get; set; } = [];
}
```

#### `{Entity}UpdateCommand.cs`
```csharp
using MediatR;

namespace {ModelsNamespace};

public class {Entity}UpdateCommand : IRequest<bool>
{
    public long Id { get; set; }
    // CreateCommand-dagi barcha maydonlar + o'zgartirilishi mumkin bo'lganlar

    // Sub-kolleksiya bo'lsa (create + update birlashtiriladi):
    public List<{Entity}{Sub}UpdateCommand> {Subs} { get; set; } = [];
}
```

#### `{Entity}DeleteCommand.cs`
```csharp
using MediatR;

namespace {ModelsNamespace};

public class {Entity}DeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
```

#### Status Commands (`UpdateStatus/` papkasida) — faqat Doc uchun
```csharp
using MediatR;

namespace {ModelsNamespace};

public class {Entity}AcceptCommand : IRequest<bool>
{
    public long Id { get; set; }
}
// Xuddi shunday: Cancel, Revoke, Send, Reject ...
```

#### Sub-kolleksiya Commands (`Collection/` papkasida) — **IRequest yo'q!**
```csharp
namespace {ModelsNamespace};

// Faqat data class — IRequest yo'q
public class {Entity}{Sub}CreateCommand
{
    public int {Sub}TypeId { get; set; }
    public decimal Amount { get; set; }
    // ...
    public List<{Entity}{Sub}FileCreateCommand> Files { get; set; } = [];
}

public class {Entity}{Sub}UpdateCommand
{
    public long? Id { get; set; }  // null → yangi qo'shilgan
    public bool IsDeleted { get; set; }
    // CreateCommand maydonlari + Id + IsDeleted
    public List<{Entity}{Sub}FileUpdateCommand> Files { get; set; } = [];
}
```

---

### 5.2 — Dtos

#### `{Entity}BriefDto.cs` — list uchun
```csharp
namespace {ModelsNamespace};

public class {Entity}BriefDto
{
    public long Id { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }  // FK → navigate property
    public int StatusId { get; set; }       // Doc uchun
    public string Status { get; set; }      // Doc uchun (Status.FullName)
    public int StateId { get; set; }        // Hl/Info uchun
    public string State { get; set; }       // Hl/Info uchun
    public DateTime DocDate { get; set; }
    public string DocNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    // ... faqat list uchun kerakli maydonlar
}
```

#### `{Entity}Dto.cs` — GetById uchun (to'liq)
```csharp
namespace {ModelsNamespace};

public class {Entity}Dto
{
    public long Id { get; set; }
    // Barcha maydonlar
    public List<{Entity}{Sub}Dto> {Subs} { get; set; } = [];
}
```

#### Sub-kolleksiya Dto
```csharp
namespace {ModelsNamespace};

public class {Entity}{Sub}Dto
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    // ...
    public List<{Entity}{Sub}FileDto> Files { get; set; } = [];
}
```

---

### 5.3 — Queries

#### `{Entity}GetByIdQuery.cs`
```csharp
using MediatR;

namespace {ModelsNamespace};

public class {Entity}GetByIdQuery : IRequest<{Entity}Dto>
{
    public long Id { get; set; }
}
```

#### `{Entity}GetBriefPageResultQuery.cs`
```csharp
using MediatR;
using WEBASE;

namespace {ModelsNamespace};

public class {Entity}GetBriefPageResultQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<{Entity}BriefDto>>
{
    // Filter maydonlar (hammasi nullable):
    public int? BranchId { get; set; }
    public int? StatusId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    // SQL scriptdagi asosiy FK kolumnlar
}
```

#### Enum uchun `{Entity}SelectListQuery.cs`
```csharp
using MediatR;

namespace {ModelsNamespace};

public class {Entity}SelectListQuery : IRequest<List<{Entity}SelectListDto>>
{
}

public class {Entity}SelectListDto
{
    public int Id { get; set; }
    public string Name { get; set; }  // tarjima bor bo'lsa
}
```

---

## APPLICATION PROJECT — Handler, Validator, Profile pattern-lar

### 5.4 — Create Handler

#### Info / Hl uchun (transaction faqat kerak bo'lganda):
```csharp
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using {ModelsNamespace};
using MediatR;
using WEBASE;

namespace {AppNamespace};

internal sealed class {Entity}CreateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<{Entity}CreateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle({Entity}CreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new {Entity}
        {
            BranchId = request.BranchId,
            DocDate = request.DocDate,
            DocNumber = request.DocNumber,
            StateId = WbStateIdConst.ACTIVE,
            // ... boshqa maydonlar
        };

        await context.{Entities}.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<long>(entity.Id);
    }
}
```

#### Doc uchun (transaction DOIMO bor):
```csharp
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Core.Constants;
using {ModelsNamespace};
using MediatR;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace {AppNamespace};

internal sealed class {Entity}CreateCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService,     // faqat fayl bo'lsa
    ILocalizationBuilder localizationBuilder) : IRequestHandler<{Entity}CreateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle({Entity}CreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = new {Entity}
        {
            BranchId = request.BranchId,
            DocDate = request.DocDate,
            DocNumber = request.DocNumber,
            StatusId = StatusIdConst.CREATED,
        };

        // Sub-kolleksiya bo'lsa:
        foreach (var sub in request.{Subs})
        {
            var subEntity = new {Entity}{Sub}
            {
                {Sub}TypeId = sub.{Sub}TypeId,
                // ...
            };

            // Sub-koleksiyaning fayllari bo'lsa:
            // (fayllarni bu yerda QOSHMAYMIZ, SaveChanges keyin Id olish uchun)
            entity.{Subs}.Add(subEntity);
        }

        await context.{Entities}.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        // Fayl bo'lsa — SaveChanges DAN KEYIN (Id kerak):
        var fileIds = request.{Subs}
            .SelectMany(s => s.Files)
            .Where(f => f.FileId.HasValue)
            .Select(f => f.FileId!.Value)
            .ToArray();

        if (fileIds.Length > 0)
            await wbStorageService.MoveToPersistentAsync(
                FileStorageConst.{ENTITY}_FILE,
                entity.Id.ToString(),
                fileIds);

        await transaction.CommitAsync(cancellationToken);

        return new WbHaveId<long>(entity.Id);
    }
}
```

---

### 5.5 — Update Handler

#### Doc uchun:
```csharp
internal sealed class {Entity}UpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<{Entity}UpdateCommand, bool>
{
    public async Task<bool> Handle({Entity}UpdateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.{Entities}
            .Include(x => x.{Subs}.Where(s => !s.IsDeleted))
                .ThenInclude(s => s.Files.Where(f => !f.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND")
                        .WithData(new { Id = request.Id }).ToString()
                });

        // Doc uchun status tekshiruvi:
        if (!StatusIdConst.Can{Entity}Status(entity.StatusId, StatusIdConst.MODIFIED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_EDITING",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_EDITING").ToString()
                });

        // Asosiy maydonlarni yangilash:
        entity.DocDate = request.DocDate;
        entity.DocNumber = request.DocNumber;
        // ...

        // Sub-kolleksiya update:
        foreach (var sub in request.{Subs})
        {
            if (sub.Id.HasValue)
            {
                var existing = entity.{Subs}.FirstOrDefault(s => s.Id == sub.Id.Value);
                if (existing is null) continue;

                if (sub.IsDeleted)
                {
                    existing.IsDeleted = true;
                    // Fayllarini ham soft-delete:
                    foreach (var f in existing.Files)
                        f.IsDeleted = true;
                    continue;
                }

                // Mavjud row update:
                existing.{Sub}TypeId = sub.{Sub}TypeId;
                // ...

                // Fayllar:
                foreach (var file in sub.Files)
                {
                    if (file.IsDeleted && file.FileId.HasValue)
                    {
                        var existingFile = existing.Files.FirstOrDefault(f => f.Id == file.FileId);
                        if (existingFile != null)
                            existingFile.IsDeleted = true;
                        // MarkFileForDeleteAsync CHAQIRILMAYDI
                    }
                    else if (file.FileId.HasValue)
                    {
                        // Yangi fayl — mark qilish (SaveChanges keyin resolve)
                        await wbStorageService.MarkFileForMoveToPersistentAsync(
                            FileStorageConst.{ENTITY}_FILE,
                            entity.Id.ToString(),
                            new[] { file.FileId.Value });
                    }
                }
            }
            else
            {
                // Yangi sub-row:
                var newSub = new {Entity}{Sub}
                {
                    {Sub}TypeId = sub.{Sub}TypeId,
                    // ...
                };
                entity.{Subs}.Add(newSub);
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        // Yangi sub-row fayllari (Id endi mavjud — SaveChanges keyin):
        foreach (var (reqSub, newSub) in newSubsWithFiles)
        {
            var newFileIds = reqSub.Files
                .Where(f => f.FileId.HasValue)
                .Select(f => f.FileId!.Value)
                .ToArray();
            if (newFileIds.Length > 0)
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.{ENTITY}_FILE,
                    newSub.Id.ToString(),
                    newFileIds);
        }
        // (newSubsWithFiles ni yuqorida to'ldirish: var newSubsWithFiles = new List<(req, entity)>())

        // Mark qilingan fayllarni resolve:
        await wbStorageService.ResolveMarkedFilesAsync(
            FileStorageConst.{ENTITY}_FILE,
            entity.Id.ToString());

        await transaction.CommitAsync(cancellationToken);
        return true;
    }
}
```

---

### 5.6 — Delete Handler

#### `status_id` bor bo'lsa (Doc):
```csharp
internal sealed class {Entity}DeleteCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<{Entity}DeleteCommand, bool>
{
    public async Task<bool> Handle({Entity}DeleteCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.{Entities}
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND")
                        .WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.Can{Entity}Status(entity.StatusId, StatusIdConst.DELETED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_DELETION",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_DELETION").ToString()
                });

        entity.StatusId = StatusIdConst.DELETED;

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return true;
    }
}
```

#### `is_deleted` bor, `status_id` yo'q (Info/Hl):
```csharp
// transaction yo'q, faqat:
entity.IsDeleted = true;
await context.SaveChangesAsync(cancellationToken);
return true;
```

---

### 5.7 — Status Handlers (faqat Doc uchun)

#### Localization key jadvali:

| Operatsiya | StatusIdConst | Key (exception) |
|---|---|---|
| Update | `MODIFIED` | `STATUS_NOT_ALLOWED_FOR_EDITING` |
| Accept | `ACCEPTED` | `STATUS_NOT_ALLOWED_FOR_APPROVAL` |
| Cancel | `CANCELLED` | `STATUS_NOT_ALLOWED_FOR_CANCELLATION` |
| Revoke | `CREATED` | `STATUS_NOT_ALLOWED_FOR_REVOCATION` |
| Send | `SENT` | `STATUS_NOT_ALLOWED_FOR_SENDING` |
| Delete | `DELETED` | `STATUS_NOT_ALLOWED_FOR_DELETION` |
| Reject | `REJECTED` | `STATUS_NOT_ALLOWED_FOR_REJECTION` |

```csharp
internal sealed class {Entity}AcceptCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<{Entity}AcceptCommand, bool>
{
    public async Task<bool> Handle({Entity}AcceptCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.{Entities}
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND")
                        .WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.Can{Entity}Status(entity.StatusId, StatusIdConst.ACCEPTED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_APPROVAL",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_APPROVAL").ToString()
                });

        entity.StatusId = StatusIdConst.ACCEPTED;

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return true;
    }
}
```

---

### 5.8 — GetById Handler

```csharp
internal sealed class {Entity}GetByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<{Entity}GetByIdQuery, {Entity}Dto>
{
    public async Task<{Entity}Dto> Handle({Entity}GetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.{Entities}
            .Include(x => x.Status)        // Doc uchun
            .Include(x => x.State)         // Hl/Info uchun
            .Include(x => x.Branch)
            // Sub-kolleksiya bo'lsa (soft-delete filter bilan):
            .Include(x => x.{Subs}.Where(s => !s.IsDeleted))
                .ThenInclude(s => s.Files.Where(f => !f.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND")
                        .WithData(new { Id = request.Id }).ToString()
                });

        return mapper.Map<{Entity}Dto>(entity);
    }
}
```

---

### 5.9 — GetBriefAsPagedResult Handler

#### Tarjima yo'q:
```csharp
internal sealed class {Entity}GetBriefPageResultQueryHandler(
    IApplicationDbContext context,
    IMapper mapper) : IRequestHandler<{Entity}GetBriefPageResultQuery, WbPagedResult<{Entity}BriefDto>>
{
    public async Task<WbPagedResult<{Entity}BriefDto>> Handle(
        {Entity}GetBriefPageResultQuery request, CancellationToken cancellationToken)
    {
        var query = context.{Entities}
            .Where(x => !x.IsDeleted)            // soft-delete bo'lsa
            .AsQueryable();

        // Filter-lar:
        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);
        if (request.StatusId.HasValue)
            query = query.Where(x => x.StatusId == request.StatusId);
        if (request.FromDate.HasValue)
            query = query.Where(x => x.DocDate >= request.FromDate);
        if (request.ToDate.HasValue)
            query = query.Where(x => x.DocDate <= request.ToDate);

        var mappedQuery = query.Select(x => new {Entity}BriefDto
        {
            Id = x.Id,
            BranchId = x.BranchId,
            BranchName = x.Branch.FullName,
            StatusId = x.StatusId,
            Status = x.Status.FullName,
            DocDate = x.DocDate,
            DocNumber = x.DocNumber,
            CreatedAt = x.CreatedAt,
        });

        if (request.HasSearch())
            mappedQuery = mappedQuery.Where(x =>
                x.DocNumber.ToLower().Contains(request.Search!.ToLower()));

        return await mappedQuery.AsPagedResultAsync(request);
    }
}
```

#### Tarjima bor (`_translate` jadvali mavjud):
```csharp
internal sealed class {Entity}GetBriefPageResultQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<{Entity}GetBriefPageResultQuery, WbPagedResult<{Entity}BriefDto>>
{
    public async Task<WbPagedResult<{Entity}BriefDto>> Handle(
        {Entity}GetBriefPageResultQuery request, CancellationToken cancellationToken)
    {
        var query = context.{Entities}
            .Where(x => !x.IsDeleted)
            .MapTo<{Entity}BriefDto>(mapper, cultureHelper);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.HasSearch())
            query = query.Where(x => x.Name.ToLower().Contains(request.Search!.ToLower()));

        return await query.AsPagedResultAsync(request);
    }
}
```

---

### 5.10 — Validators

```csharp
using FluentValidation;
using {ModelsNamespace};

namespace {AppNamespace};

public class {Entity}CreateCommandValidator : AbstractValidator<{Entity}CreateCommand>
{
    public {Entity}CreateCommandValidator()
    {
        RuleFor(x => x.BranchId).GreaterThan(0)
            .WithMessage($"{nameof({Entity}CreateCommand.BranchId)} is required");
        RuleFor(x => x.DocDate).NotNull()
            .WithMessage($"{nameof({Entity}CreateCommand.DocDate)} is required");
        // ... SQL NOT NULL kolumnlar uchun
    }
}

public class {Entity}UpdateCommandValidator : AbstractValidator<{Entity}UpdateCommand>
{
    public {Entity}UpdateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage($"{nameof({Entity}UpdateCommand.Id)} is required");
        // CreateCommandValidator bilan bir xil qoidalar + Id
    }
}
```

---

### 5.11 — Profiles

#### Tarjima yo'q — oddiy `Profile`:
```csharp
using AutoMapper;
using Erp.Core.Service.Domain;
using {ModelsNamespace};

namespace {AppNamespace};

public class {Entity}BriefDtoProfile : Profile
{
    public {Entity}BriefDtoProfile()
    {
        CreateMap<{Entity}, {Entity}BriefDto>()
            .ForMember(dest => dest.BranchName, conf => conf.MapFrom(src => src.Branch.FullName))
            .ForMember(dest => dest.Status, conf => conf.MapFrom(src => src.Status.FullName));
            // navigate property orqali olinadigan maydonlar ForMember bilan yoziladi
            // To'g'ridan-to'g'ri mos keladiganlar avtomatik mappalanadi

        CreateMap<{Entity}{Sub}, {Entity}{Sub}Dto>();

        // GetById uchun to'liq Dto:
        CreateMap<{Entity}, {Entity}Dto>()
            .ForMember(dest => dest.Status, conf => conf.MapFrom(src => src.Status.FullName));
    }
}
```

#### Tarjima bor — `CultureProfile` dan meros:
```csharp
using Erp.Core.Service.Application.Mapping;
using Erp.Core.Service.Domain;
using {ModelsNamespace};

namespace {AppNamespace};

public class {Entity}BriefDtoProfile : CultureProfile
{
    public {Entity}BriefDtoProfile()
    {
        // cultureId = 1 (default, ishlab turibdi)
        CreateMap<{Entity}, {Entity}BriefDto>()
            .ForMember(dest => dest.Name, conf => conf.MapFrom(
                src => src.Translates
                    .Where(t => t.LanguageId == cultureId)
                    .Select(t => t.FullName)
                    .FirstOrDefault()))
            .ForMember(dest => dest.ShortName, conf => conf.MapFrom(
                src => src.Translates
                    .Where(t => t.LanguageId == cultureId)
                    .Select(t => t.ShortName)
                    .FirstOrDefault()));
    }
}
```

---

## NAMING CONVENTION — To'liq jadval

### Models fayllari

| Tur | Fayl | Interfeys |
|---|---|---|
| Create | `{Entity}CreateCommand.cs` | `IRequest<WbHaveId<long>>` |
| Update | `{Entity}UpdateCommand.cs` | `IRequest<bool>` |
| Delete | `{Entity}DeleteCommand.cs` | `IRequest<bool>` |
| Status | `{Entity}AcceptCommand.cs` | `IRequest<bool>` |
| Sub (create) | `{Entity}{Sub}CreateCommand.cs` | **yo'q** |
| Sub (update) | `{Entity}{Sub}UpdateCommand.cs` | **yo'q** |
| BriefDto | `{Entity}BriefDto.cs` | — |
| FullDto | `{Entity}Dto.cs` | — |
| Sub Dto | `{Entity}{Sub}Dto.cs` | — |
| GetById | `{Entity}GetByIdQuery.cs` | `IRequest<{Entity}Dto>` |
| GetList | `{Entity}GetBriefPageResultQuery.cs` | `IRequest<WbPagedResult<{Entity}BriefDto>>` |
| Enum | `{Entity}SelectListQuery.cs` | `IRequest<List<{Entity}SelectListDto>>` |

### Application fayllari

| Tur | Fayl |
|---|---|
| Create handler | `{Entity}CreateCommandHandler.cs` |
| Create validator | `{Entity}CreateCommandValidator.cs` |
| Update handler | `{Entity}UpdateCommandHandler.cs` |
| Update validator | `{Entity}UpdateCommandValidator.cs` |
| Delete handler | `{Entity}DeleteCommandHandler.cs` |
| Accept handler | `{Entity}AcceptCommandHandler.cs` |
| GetById handler | `{Entity}GetByIdQueryHandler.cs` |
| GetById validator | `{Entity}GetByIdQueryValidator.cs` |
| GetList handler | `{Entity}GetBriefPageResultQueryHandler.cs` |
| Profile | `{Entity}BriefDtoProfile.cs` |

---

## PAPKA TUZILMASI

### Models project

```
{ModelsProject}/
  {Category}/{EntityName}/
    Commands/
      {Entity}CreateCommand.cs
      {Entity}UpdateCommand.cs
      {Entity}DeleteCommand.cs
      UpdateStatus/
        {Entity}AcceptCommand.cs
        {Entity}CancelCommand.cs
        {Entity}RevokeCommand.cs
      Collection/
        {Entity}{Sub}CreateCommand.cs   ← IRequest yo'q
        {Entity}{Sub}UpdateCommand.cs   ← IRequest yo'q
    Dtos/
      {Entity}BriefDto.cs
      {Entity}Dto.cs
      Collection/
        {Entity}{Sub}Dto.cs
    Queries/
      {Entity}GetByIdQuery.cs
      {Entity}GetBriefPageResultQuery.cs
```

### Application project

```
UseCases/{Category}/{EntityName}/
  Command/
    Create/
      {Entity}CreateCommandHandler.cs
      {Entity}CreateCommandValidator.cs
    Update/
      {Entity}UpdateCommandHandler.cs
      {Entity}UpdateCommandValidator.cs
    Delete/
      {Entity}DeleteCommandHandler.cs
    UpdateStatus/
      Accept/
        {Entity}AcceptCommandHandler.cs
      Cancel/
        {Entity}CancelCommandHandler.cs
  Query/
    GetById/
      {Entity}GetByIdQueryHandler.cs
      {Entity}GetByIdQueryValidator.cs
    GetBriefAsPagedResult/
      {Entity}GetBriefPageResultQueryHandler.cs
  Profile/
    Queries/
      {Entity}BriefDtoProfile.cs
```

---

## MUHIM QOIDALAR (esdan chiqarma)

1. **Transaction**:
   - `Doc` → **barcha** handler-larda (`Create`, `Update`, `Delete`, `Accept`, `Cancel`, ...)
   - `Info`/`Hl` → faqat multi-step save bo'lsa

2. **try/catch yo'q** — `using var transaction` o'zi rollback qiladi

3. **File soft-delete** → `f.IsDeleted = true` faqat. `MarkFileForDeleteAsync` **chaqirilmaydi**

4. **Sub-row soft-delete** → `row.IsDeleted = true` faqat

5. **Yangi sub-row fayllari** → avval `SaveChanges` (Id olish), keyin `MoveToPersistentAsync`

6. **Mavjud sub-row yangi fayllari** → `MarkFileForMoveToPersistentAsync` → `ResolveMarkedFilesAsync`

7. **Audit property**: DB-da `modified_by` → C#-da `LastModifiedBy`

8. **Status localization key** → jadvalga qarab aniq yozish

9. **Sub-kolleksiya Include** → `!IsDeleted` filter ham Include-da, ham ThenInclude-da

10. **Namespace** — barcha Models fayllari bir xil flat namespace:
    ```
    namespace {ModelsRootNamespace};
    ```
    Application fayllari:
    ```
    namespace {AppRootNamespace};
    ```

---

## BOSHLASH

Endi SQL scriptni paste qil. Men quyidagilarni qilaman:
1. Scriptni to'g'ri papkaga saqlayman
2. Entity tipini, kategoriyasini, maydonlarini tahlil qilaman
3. Savollarimni beraman
4. Tasdiqlashingdan so'ng barcha fayllarni yozaman

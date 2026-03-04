/*using System.Reflection;
using Erp.Core;
using Erp.Core.Security.PermissionCodes;
using Erp.Core.Service.Domain;
using Erp.Core.Service.Domain.Entities.Sys;
using Erp.Core.Service.Infrastructure;
using Erp.Service.Adm.Application;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Infrastructure;

public class PermissionResolver : IPermissionResolver
{
    private static bool PERMISSION_CODE_INITIALIZED = false;

    private readonly ApplicationDbContext context;
    public PermissionResolver(ApplicationDbContext setupDbContext)
    {
        context = setupDbContext;
    }

    public async Task InitIfNeededAsync()
    {
        if (!PERMISSION_CODE_INITIALIZED)
        {
            await ResolvePermissionsAsync<AdmPermissionCode, Permission, PermissionTranslate, PermissionSubGroup, PermissionSubGroupTranslate>();

            // Resolve shared permissions (MUST come AFTER native permissions)
          *//*  await ResolveSharedPermissionsAsync(typeof(LmsSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(HrmSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(ComSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(FinSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(DashSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(MySharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(OrgSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(ReprSharedPermissionCode));
            await ResolveSharedPermissionsAsync(typeof(StdSharedPermissionCode));*//*

            PERMISSION_CODE_INITIALIZED = true;
        }
    }

    public async Task ResolvePermissionsAsync<TPermissionCodeEnum, TPermission, TPermissionTranslate, TPermissionSubGroup, TPermissionSubGroupTranslate>()
        where TPermissionCodeEnum : struct
        where TPermission : class, IWbPermissionEntity<int, TPermissionTranslate, TPermissionSubGroup, TPermissionSubGroupTranslate>, new()
        where TPermissionTranslate : class, IWbTranslateEntity<int>, new()
        where TPermissionSubGroup : class, IWbPermissionSubGroupEntity<int, TPermissionSubGroupTranslate>, new()
        where TPermissionSubGroupTranslate : class, IWbTranslateEntity<int>, new()
    {
        var codeEnumAttr = typeof(TPermissionCodeEnum).GetCustomAttributes(typeof(WbPermissionEnumAttribute), false).Cast<WbPermissionEnumAttribute>().FirstOrDefault();

        if (codeEnumAttr == null)
            throw new Exception($"{nameof(WbPermissionEnumAttribute)} not found");

        var PermissionSubGroups = await context.Set<TPermissionSubGroup>()
            .Include(a => a.Translates)
            .Where(a => a.AppId == codeEnumAttr.AppId)
            .ToListAsync();

        var Permissions = await context.Set<TPermission>()
            .Include(a => a.SubGroup)
            .Include(a => a.Translates)
            .Where(a => a.AppId == codeEnumAttr.AppId)
            .ToListAsync();

        var subGroupDescs = WbPermissionHelper.GetDescriptions<TPermissionCodeEnum>();

        foreach (var subGroupDesc in subGroupDescs)
        {
            if (subGroupDesc.Key == "MusicCurriculum")
            {

            }

            var subGroup = PermissionSubGroups.FirstOrDefault(a => subGroupDesc.Key == a.Code);

            #region Init sub group
            if (subGroup == null)
            {
                subGroup = new TPermissionSubGroup
                {
                    AppId = codeEnumAttr.AppId,
                    Code = subGroupDesc.Key,
                    ShortName = subGroupDesc.Value.ShortName,
                    FullName = subGroupDesc.Value.FullName,
                    GroupId = subGroupDesc.Value.GroupId
                };
                PermissionSubGroups.Add(subGroup);
                await context.Set<TPermissionSubGroup>().AddAsync(subGroup);

                context.Entry(subGroup).State = EntityState.Added;

                foreach (var item in subGroupDesc.Value.Translates)
                {
                    var translateEntity = new TPermissionSubGroupTranslate
                    {
                        ColumnName = item.ShortNameColumnName,
                        LanguageId = item.LanguageId,
                        TranslateText = item.ShortName
                    };

                    subGroup.Translates.Add(translateEntity);
                    context.Set<TPermissionSubGroupTranslate>().Add(translateEntity);
                    context.Entry(translateEntity).State = EntityState.Added;
                    translateEntity = new TPermissionSubGroupTranslate
                    {
                        ColumnName = item.FullNameColumnName,
                        LanguageId = item.LanguageId,
                        TranslateText = item.FullName
                    };
                    subGroup.Translates.Add(translateEntity);
                    await context.Set<TPermissionSubGroupTranslate>().AddAsync(translateEntity);
                    context.Entry(translateEntity).State = EntityState.Added;
                }
            }
            else
            {
                if (subGroup.ShortName != subGroupDesc.Value.ShortName || subGroup.FullName != subGroupDesc.Value.FullName || subGroup.GroupId != subGroupDesc.Value.GroupId)
                {
                    subGroup.AppId = codeEnumAttr.AppId;
                    subGroup.ShortName = subGroupDesc.Value.ShortName;
                    subGroup.FullName = subGroupDesc.Value.FullName;
                    subGroup.GroupId = subGroupDesc.Value.GroupId;
                    context.Entry(subGroup).State = EntityState.Modified;
                }

                #region Update translates
                foreach (var translateDescription in subGroupDesc.Value.Translates)
                {
                    var shortNameTranslateEntity = subGroup.Translates.FirstOrDefault(a => a.LanguageId == translateDescription.LanguageId && a.ColumnName == translateDescription.ShortNameColumnName);
                    if (shortNameTranslateEntity == null)
                    {
                        subGroup.Translates.Add(new TPermissionSubGroupTranslate
                        {
                            ColumnName = translateDescription.ShortNameColumnName,
                            LanguageId = translateDescription.LanguageId,
                            TranslateText = translateDescription.ShortName
                        });
                    }
                    else
                    {
                        if (shortNameTranslateEntity.TranslateText != translateDescription.ShortName)
                        {
                            shortNameTranslateEntity.TranslateText = translateDescription.ShortName;
                            context.Entry(shortNameTranslateEntity).State = EntityState.Modified;
                        }
                    }

                    var fullNameTranslateEntity = subGroup.Translates.FirstOrDefault(a => a.LanguageId == translateDescription.LanguageId && a.ColumnName == translateDescription.FullNameColumnName);
                    if (fullNameTranslateEntity == null)
                    {
                        subGroup.Translates.Add(new TPermissionSubGroupTranslate
                        {
                            ColumnName = translateDescription.FullNameColumnName,
                            LanguageId = translateDescription.LanguageId,
                            TranslateText = translateDescription.FullName
                        });
                    }
                    else
                    {
                        if (fullNameTranslateEntity.TranslateText != translateDescription.FullName)
                        {
                            fullNameTranslateEntity.TranslateText = translateDescription.FullName;
                            context.Entry(fullNameTranslateEntity).State = EntityState.Modified;
                        }
                    }
                }

                foreach (var subGroupTranslate in subGroup.Translates.Where(a => !subGroupDesc.Value.Translates
                    .Any(b => a.LanguageId == b.LanguageId && (a.ColumnName == b.ShortNameColumnName || a.ColumnName == b.FullNameColumnName))))
                {
                    context.Entry(subGroupTranslate).State = EntityState.Deleted;
                }
                #endregion
            }
            #endregion

            #region resolve Permission groups

            foreach (var PermissionDesc in subGroupDesc.Value.PermissionCodes)
            {
                var Permission = Permissions.FirstOrDefault(a => a.Code == PermissionDesc.Code);

                if (Permission == null)
                {
                    Permission = new TPermission
                    {
                        AppId = codeEnumAttr.AppId,
                        Code = PermissionDesc.Code,
                        ShortName = PermissionDesc.ShortName,
                        FullName = PermissionDesc.FullName,
                        SubGroup = subGroup
                    };
                    Permissions.Add(Permission);
                    await context.Set<TPermission>().AddAsync(Permission);
                    context.Entry(Permission).State = EntityState.Added;

                    foreach (var item in PermissionDesc.Translates)
                    {
                        var translateEntity = new TPermissionTranslate
                        {
                            ColumnName = item.ShortNameColumnName,
                            LanguageId = item.LanguageId,
                            TranslateText = item.ShortName
                        };
                        Permission.Translates.Add(translateEntity);
                        await context.Set<TPermissionTranslate>().AddAsync(translateEntity);
                        context.Entry(translateEntity).State = EntityState.Added;
                        translateEntity = new TPermissionTranslate
                        {
                            ColumnName = item.FullNameColumnName,
                            LanguageId = item.LanguageId,
                            TranslateText = item.FullName
                        };
                        Permission.Translates.Add(translateEntity);
                        await context.Set<TPermissionTranslate>().AddAsync(translateEntity);
                        context.Entry(translateEntity).State = EntityState.Added;
                    }
                }
                else
                {
                    if (Permission.ShortName != PermissionDesc.ShortName || Permission.FullName != PermissionDesc.FullName || Permission.SubGroup != subGroup)
                    {
                        Permission.AppId = codeEnumAttr.AppId;
                        Permission.ShortName = PermissionDesc.ShortName;
                        Permission.FullName = PermissionDesc.FullName;
                        Permission.SubGroup = subGroup;
                        context.Entry(Permission).State = EntityState.Modified;
                    }

                    #region Update translates
                    foreach (var translateDescription in PermissionDesc.Translates)
                    {
                        var shortNameTranslateEntity = Permission.Translates.FirstOrDefault(a => a.LanguageId == translateDescription.LanguageId && a.ColumnName == translateDescription.ShortNameColumnName);
                        if (shortNameTranslateEntity == null)
                        {
                            shortNameTranslateEntity = new TPermissionTranslate
                            {
                                ColumnName = translateDescription.ShortNameColumnName,
                                LanguageId = translateDescription.LanguageId,
                                TranslateText = translateDescription.ShortName
                            };
                            Permission.Translates.Add(shortNameTranslateEntity);
                            await context.Set<TPermissionTranslate>().AddAsync(shortNameTranslateEntity);
                            context.Entry(shortNameTranslateEntity).State = EntityState.Added;
                        }
                        else
                        {
                            if (shortNameTranslateEntity.TranslateText != translateDescription.ShortName)
                            {
                                shortNameTranslateEntity.TranslateText = translateDescription.ShortName;
                                context.Entry(shortNameTranslateEntity).State = EntityState.Modified;
                            }
                        }

                        var fullNameTranslateEntity = Permission.Translates.FirstOrDefault(a => a.LanguageId == translateDescription.LanguageId && a.ColumnName == translateDescription.FullNameColumnName);
                        if (fullNameTranslateEntity == null)
                        {
                            fullNameTranslateEntity = new TPermissionTranslate
                            {
                                ColumnName = translateDescription.FullNameColumnName,
                                LanguageId = translateDescription.LanguageId,
                                TranslateText = translateDescription.FullName
                            };
                            Permission.Translates.Add(fullNameTranslateEntity);
                            await context.Set<TPermissionTranslate>().AddAsync(fullNameTranslateEntity);
                            context.Entry(fullNameTranslateEntity).State = EntityState.Added;
                        }
                        else
                        {
                            if (fullNameTranslateEntity.TranslateText != translateDescription.FullName)
                            {
                                fullNameTranslateEntity.TranslateText = translateDescription.FullName;
                                context.Entry(fullNameTranslateEntity).State = EntityState.Modified;
                            }
                        }
                    }

                    foreach (var PermissionTranslate in Permission.Translates.Where(a => !PermissionDesc.Translates
                        .Any(b => a.LanguageId == b.LanguageId && (a.ColumnName == b.ShortNameColumnName || a.ColumnName == b.FullNameColumnName))))
                    {
                        context.Entry(PermissionTranslate).State = EntityState.Deleted;
                    }
                    #endregion
                }
            }

            #endregion
        }

        //var PermissionCodes = subGroupDescs.SelectMany(a => a.Value.PermissionCodes.Select(a => new { a.Code, a.AppId }));
        HashSet<string> PermissionCodes = subGroupDescs.SelectMany(a => a.Value.PermissionCodes.Select(a => a.Code)).ToHashSet();

        var permissionCodesToDelete = Permissions
            .Where(a => !PermissionCodes.Contains(a.Code))
            .Select(a => a.Id)
            .ToList();

        var rolePermissionsToDelete = await context.RolePermissions
            .Where(rp => permissionCodesToDelete.Contains(rp.PermissionId))
            .ToListAsync();

        foreach (var item in rolePermissionsToDelete)
        {
            context.Entry(item).State = EntityState.Deleted;
        }
        
        foreach (var item in Permissions.Where(a => !PermissionCodes.Contains(a.Code)))
        {
            context.Entry(item).State = EntityState.Deleted;
            foreach (var subItem in item.Translates)
                context.Entry(subItem).State = EntityState.Deleted;
        }

        foreach (var item in PermissionSubGroups.Where(a => !subGroupDescs.ContainsKey(a.Code)))
        {
            context.Entry(item).State = EntityState.Deleted;
            foreach (var subItem in item.Translates)
                context.Entry(subItem).State = EntityState.Deleted;
        }

        try
        {
            context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Shared permission larni resolve qiladi.
    /// Masalan: LmsSharedPermissionCode dan HRM, ADM permission larini o'qib,
    /// ularni LMS app ga is_shared=true bilan ko'chirib yozadi.
    /// </summary>
    public async Task ResolveSharedPermissionsAsync(Type sharedPermissionType)
    {
        // =====================================================================
        // PART 1: Shared permission class dan ma'lumotlarni o'qish (Reflection)
        // =====================================================================

        // 1.1 TargetAppId ni olish - qaysi app ga permission lar ko'chiriladi
        // Masalan: LmsSharedPermissionCode.TargetAppId = AppIdConst.LMS (7)
        var targetAppIdField = sharedPermissionType.GetField("TargetAppId", BindingFlags.Public | BindingFlags.Static);
        if (targetAppIdField == null)
            throw new Exception($"TargetAppId const not found in {sharedPermissionType.Name}");

        var targetAppId = (int)targetAppIdField.GetValue(null);

        // 1.2 Class dagi barcha enum array larni topish
        // Masalan: HrmPermissionCode[], AdmPermissionCode[]
        var permissionArrayFields = sharedPermissionType
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType.IsArray && f.FieldType.GetElementType().IsEnum)
            .ToList();

        // 1.3 Har bir enum array dan permission code va source app id ni olish
        var sharedPermissionInfos = new List<(string PermissionCode, int SourceAppId)>();

        foreach (var field in permissionArrayFields)
        {
            // Enum type dan AppId ni olish (WbPermissionEnumAttribute dan)
            // Masalan: HrmPermissionCode enum da [WbPermissionEnum(AppId = 3)] bor
            var enumType = field.FieldType.GetElementType();
            var enumAttr = enumType.GetCustomAttribute<WbPermissionEnumAttribute>();

            if (enumAttr == null)
                continue; // Permission enum emas, o'tkazib yuborish

            var sourceAppId = enumAttr.AppId; // Masalan: HRM = 3
            var enumValues = (Array)field.GetValue(null);

            // Har bir enum qiymatni list ga qo'shish
            // Masalan: ("EmployeeView", 3), ("EmployeeCreate", 3)
            foreach (var enumValue in enumValues)
            {
                var permissionCode = enumValue.ToString();
                sharedPermissionInfos.Add((permissionCode, sourceAppId));
            }
        }

        // Agar shared permission yo'q bo'lsa, to'xtatish
        if (sharedPermissionInfos.Count == 0)
            return;

        // =====================================================================
        // PART 2: Database dan mavjud ma'lumotlarni yuklash
        // =====================================================================

        // 2.1 Target app (LMS) da allaqachon mavjud shared subgroup va permission larni yuklash
        var existingSharedSubGroups = await context.PermissionSubGroups
            .Include(sg => sg.Translates)
            .Where(sg => sg.AppId == targetAppId && sg.IsShared)
            .ToListAsync();

        var existingSharedPermissions = await context.Permissions
            .Include(p => p.Translates)
            .Where(p => p.AppId == targetAppId && p.IsShared)
            .ToListAsync();

        // 2.2 Source app (HRM, ADM) lardan original permission va subgroup larni yuklash
        var sourceAppIds = sharedPermissionInfos.Select(p => p.SourceAppId).Distinct().ToList();

        var sourceSubGroups = await context.PermissionSubGroups
            .Include(sg => sg.Translates)
            .Where(sg => sourceAppIds.Contains(sg.AppId) && !sg.IsShared)
            .ToListAsync();

        var sourcePermissions = await context.Permissions
            .Include(p => p.Translates)
            .Include(p => p.SubGroup)
            .Where(p => sourceAppIds.Contains(p.AppId) && !p.IsShared)
            .ToListAsync();

        // =====================================================================
        // PART 3: Kerakli SubGroup larni aniqlash
        // =====================================================================

        // Permission lar SubGroup ga bog'liq, shuning uchun avval qaysi SubGroup lar kerakligini aniqlaymiz
        // Masalan: EmployeeView permission Employee subgroup ga tegishli
        var requiredSubGroups = new HashSet<(string SubGroupCode, int SourceAppId)>();

        foreach (var permInfo in sharedPermissionInfos)
        {
            // Source permission ni topish
            var sourcePermission = sourcePermissions.FirstOrDefault(
                p => p.Code == permInfo.PermissionCode && p.AppId == permInfo.SourceAppId);

            // Uning SubGroup ini kerakli list ga qo'shish
            if (sourcePermission?.SubGroup != null)
            {
                requiredSubGroups.Add((sourcePermission.SubGroup.Code, permInfo.SourceAppId));
            }
        }

        // =====================================================================
        // PART 4: SubGroup larni yaratish yoki yangilash
        // =====================================================================

        // SubGroup lar avval yaratilishi kerak, chunki Permission lar ularga bog'lanadi
        foreach (var subGroupInfo in requiredSubGroups)
        {
            // Source subgroup ni topish (HRM dagi original)
            var sourceSubGroup = sourceSubGroups.FirstOrDefault(
                sg => sg.Code == subGroupInfo.SubGroupCode && sg.AppId == subGroupInfo.SourceAppId);

            if (sourceSubGroup == null)
                continue; // Source topilmasa, o'tkazib yuborish

            // LMS da allaqachon shared copy bormi tekshirish
            var existingSharedSubGroup = existingSharedSubGroups.FirstOrDefault(
                sg => sg.Code == subGroupInfo.SubGroupCode && sg.SourceAppId == subGroupInfo.SourceAppId);

            if (existingSharedSubGroup == null)
            {
                // YARATISH: Yangi shared subgroup yaratish
                var newSubGroup = new PermissionSubGroup
                {
                    AppId = targetAppId,                    // LMS (7)
                    Code = sourceSubGroup.Code,             // "Employee"
                    ShortName = sourceSubGroup.ShortName,
                    FullName = sourceSubGroup.FullName,
                    GroupId = sourceSubGroup.GroupId,
                    OrderCode = sourceSubGroup.OrderCode,
                    IsShared = true,                        // Bu shared copy
                    SourceAppId = subGroupInfo.SourceAppId  // HRM (3) dan ko'chirilgan
                };

                await context.PermissionSubGroups.AddAsync(newSubGroup);

                // Tarjimalarni ko'chirish (uz, ru, en)
                foreach (var translate in sourceSubGroup.Translates)
                {
                    var newTranslate = new PermissionSubGroupTranslate
                    {
                        ColumnName = translate.ColumnName,
                        LanguageId = translate.LanguageId,
                        TranslateText = translate.TranslateText
                    };
                    newSubGroup.Translates.Add(newTranslate);
                    await context.PermissionSubGroupTranslates.AddAsync(newTranslate);
                }

                existingSharedSubGroups.Add(newSubGroup);
            }
            else
            {
                // YANGILASH: Source o'zgarganda shared copy ni ham yangilash
                UpdateSharedSubGroup(existingSharedSubGroup, sourceSubGroup);
            }
        }

        // SubGroup larni saqlash (Permission lar uchun ID kerak)
        await context.SaveChangesAsync();

        // SubGroup larni qayta yuklash (yangi ID larni olish uchun)
        existingSharedSubGroups = await context.PermissionSubGroups
            .Include(sg => sg.Translates)
            .Where(sg => sg.AppId == targetAppId && sg.IsShared)
            .ToListAsync();

        // =====================================================================
        // PART 5: Permission larni yaratish yoki yangilash
        // =====================================================================

        foreach (var permInfo in sharedPermissionInfos)
        {
            // Source permission ni topish (HRM dagi original)
            var sourcePermission = sourcePermissions.FirstOrDefault(
                p => p.Code == permInfo.PermissionCode && p.AppId == permInfo.SourceAppId);

            if (sourcePermission?.SubGroup == null)
                continue;

            // LMS dagi shared subgroup ni topish (permission shunga bog'lanadi)
            var sharedSubGroup = existingSharedSubGroups.FirstOrDefault(
                sg => sg.Code == sourcePermission.SubGroup.Code && sg.SourceAppId == permInfo.SourceAppId);

            if (sharedSubGroup == null)
                continue;

            // LMS da allaqachon shared permission bormi tekshirish
            var existingSharedPerm = existingSharedPermissions.FirstOrDefault(
                p => p.Code == permInfo.PermissionCode && p.SourceAppId == permInfo.SourceAppId);

            if (existingSharedPerm == null)
            {
                // YARATISH: Yangi shared permission yaratish
                var newPerm = new Permission
                {
                    AppId = targetAppId,                // LMS (7)
                    Code = sourcePermission.Code,       // "EmployeeView"
                    ShortName = sourcePermission.ShortName,
                    FullName = sourcePermission.FullName,
                    OrderCode = sourcePermission.OrderCode,
                    SubGroupId = sharedSubGroup.Id,     // LMS dagi shared subgroup ga bog'lash
                    IsShared = true,                    // Bu shared copy
                    SourceAppId = permInfo.SourceAppId  // HRM (3) dan ko'chirilgan
                };

                await context.Permissions.AddAsync(newPerm);

                // Tarjimalarni ko'chirish (uz, ru, en)
                foreach (var translate in sourcePermission.Translates)
                {
                    var newTranslate = new PermissionTranslate
                    {
                        ColumnName = translate.ColumnName,
                        LanguageId = translate.LanguageId,
                        TranslateText = translate.TranslateText
                    };
                    newPerm.Translates.Add(newTranslate);
                    await context.PermissionTranslates.AddAsync(newTranslate);
                }

                existingSharedPermissions.Add(newPerm);
            }
            else
            {
                // YANGILASH: Source o'zgarganda shared copy ni ham yangilash
                UpdateSharedPermission(existingSharedPerm, sourcePermission, sharedSubGroup.Id);
            }
        }

        // =====================================================================
        // PART 6: Eski (olib tashlangan) shared permission/subgroup larni o'chirish
        // =====================================================================

        // 6.1 Code dan olib tashlangan permission larni o'chirish
        // Masalan: LmsSharedPermissionCode dan EmployeeCreate olib tashlansa
        var validPermissionCodes = sharedPermissionInfos.Select(p => p.PermissionCode).ToHashSet();
        var permissionsToDelete = existingSharedPermissions
            .Where(p => !validPermissionCodes.Contains(p.Code))
            .ToList();

        foreach (var perm in permissionsToDelete)
        {
            // Avval RolePermission bog'lanishlarini o'chirish (FK constraint)
            var rolePermissions = await context.RolePermissions
                .Where(rp => rp.PermissionId == perm.Id)
                .ToListAsync();

            foreach (var rp in rolePermissions)
            {
                context.Entry(rp).State = EntityState.Deleted;
            }

            // Tarjimalarni o'chirish
            foreach (var translate in perm.Translates)
            {
                context.Entry(translate).State = EntityState.Deleted;
            }

            // Permission ni o'chirish
            context.Entry(perm).State = EntityState.Deleted;
        }

        // 6.2 Endi kerak bo'lmagan subgroup larni o'chirish
        var validSubGroupCodes = requiredSubGroups.Select(sg => sg.SubGroupCode).ToHashSet();
        var subGroupsToDelete = existingSharedSubGroups
            .Where(sg => !validSubGroupCodes.Contains(sg.Code))
            .ToList();

        foreach (var sg in subGroupsToDelete)
        {
            // Tarjimalarni o'chirish
            foreach (var translate in sg.Translates)
            {
                context.Entry(translate).State = EntityState.Deleted;
            }

            // SubGroup ni o'chirish
            context.Entry(sg).State = EntityState.Deleted;
        }

        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Shared SubGroup ni source dan yangilash.
    /// Agar source da nom yoki boshqa field o'zgargan bo'lsa, shared copy ham yangilanadi.
    /// </summary>
    private void UpdateSharedSubGroup(PermissionSubGroup target, PermissionSubGroup source)
    {
        bool needsUpdate = false;

        // Nomlarni tekshirish va yangilash
        if (target.ShortName != source.ShortName)
        {
            target.ShortName = source.ShortName;
            needsUpdate = true;
        }
        if (target.FullName != source.FullName)
        {
            target.FullName = source.FullName;
            needsUpdate = true;
        }
        if (target.GroupId != source.GroupId)
        {
            target.GroupId = source.GroupId;
            needsUpdate = true;
        }
        if (target.OrderCode != source.OrderCode)
        {
            target.OrderCode = source.OrderCode;
            needsUpdate = true;
        }

        if (needsUpdate)
        {
            context.Entry(target).State = EntityState.Modified;
        }

        // Tarjimalarni sinxronlashtirish
        SyncSubGroupTranslates(target, source);
    }

    /// <summary>
    /// Shared Permission ni source dan yangilash.
    /// </summary>
    private void UpdateSharedPermission(Permission target, Permission source, int sharedSubGroupId)
    {
        bool needsUpdate = false;

        // Nomlarni tekshirish va yangilash
        if (target.ShortName != source.ShortName)
        {
            target.ShortName = source.ShortName;
            needsUpdate = true;
        }
        if (target.FullName != source.FullName)
        {
            target.FullName = source.FullName;
            needsUpdate = true;
        }
        if (target.OrderCode != source.OrderCode)
        {
            target.OrderCode = source.OrderCode;
            needsUpdate = true;
        }
        if (target.SubGroupId != sharedSubGroupId)
        {
            target.SubGroupId = sharedSubGroupId;
            needsUpdate = true;
        }

        if (needsUpdate)
        {
            context.Entry(target).State = EntityState.Modified;
        }

        // Tarjimalarni sinxronlashtirish
        SyncPermissionTranslates(target, source);
    }

    /// <summary>
    /// SubGroup tarjimalarini source dan target ga sinxronlashtirish.
    /// Yangi tarjimalar qo'shiladi, mavjudlari yangilanadi, o'chirilganlari o'chiriladi.
    /// </summary>
    private void SyncSubGroupTranslates(PermissionSubGroup target, PermissionSubGroup source)
    {
        // Yangi va o'zgargan tarjimalarni qo'shish/yangilash
        foreach (var sourceTranslate in source.Translates)
        {
            var existingTranslate = target.Translates.FirstOrDefault(
                t => t.LanguageId == sourceTranslate.LanguageId && t.ColumnName == sourceTranslate.ColumnName);

            if (existingTranslate == null)
            {
                // Yangi tarjima qo'shish
                var newTranslate = new PermissionSubGroupTranslate
                {
                    ColumnName = sourceTranslate.ColumnName,
                    LanguageId = sourceTranslate.LanguageId,
                    TranslateText = sourceTranslate.TranslateText
                };
                target.Translates.Add(newTranslate);
                context.PermissionSubGroupTranslates.Add(newTranslate);
            }
            else if (existingTranslate.TranslateText != sourceTranslate.TranslateText)
            {
                // Mavjud tarjimani yangilash
                existingTranslate.TranslateText = sourceTranslate.TranslateText;
                context.Entry(existingTranslate).State = EntityState.Modified;
            }
        }

        // Source da yo'q bo'lgan tarjimalarni o'chirish
        var sourceKeys = source.Translates.Select(t => (t.LanguageId, t.ColumnName)).ToHashSet();
        var translatestoRemove = target.Translates
            .Where(t => !sourceKeys.Contains((t.LanguageId, t.ColumnName)))
            .ToList();

        foreach (var translate in translatestoRemove)
        {
            context.Entry(translate).State = EntityState.Deleted;
        }
    }

    /// <summary>
    /// Permission tarjimalarini source dan target ga sinxronlashtirish.
    /// </summary>
    private void SyncPermissionTranslates(Permission target, Permission source)
    {
        // Yangi va o'zgargan tarjimalarni qo'shish/yangilash
        foreach (var sourceTranslate in source.Translates)
        {
            var existingTranslate = target.Translates.FirstOrDefault(
                t => t.LanguageId == sourceTranslate.LanguageId && t.ColumnName == sourceTranslate.ColumnName);

            if (existingTranslate == null)
            {
                // Yangi tarjima qo'shish
                var newTranslate = new PermissionTranslate
                {
                    ColumnName = sourceTranslate.ColumnName,
                    LanguageId = sourceTranslate.LanguageId,
                    TranslateText = sourceTranslate.TranslateText
                };
                target.Translates.Add(newTranslate);
                context.PermissionTranslates.Add(newTranslate);
            }
            else if (existingTranslate.TranslateText != sourceTranslate.TranslateText)
            {
                // Mavjud tarjimani yangilash
                existingTranslate.TranslateText = sourceTranslate.TranslateText;
                context.Entry(existingTranslate).State = EntityState.Modified;
            }
        }

        // Source da yo'q bo'lgan tarjimalarni o'chirish
        var sourceKeys = source.Translates.Select(t => (t.LanguageId, t.ColumnName)).ToHashSet();
        var translatestoRemove = target.Translates
            .Where(t => !sourceKeys.Contains((t.LanguageId, t.ColumnName)))
            .ToList();

        foreach (var translate in translatestoRemove)
        {
            context.Entry(translate).State = EntityState.Deleted;
        }
    }
}
*/

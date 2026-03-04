using Erp.Core;
using Erp.Core.Security;
using Erp.Core.Service.Domain;
using WEBASE;

namespace Erp.Service.Adm.Job.Application;

public static class UserAuthModelSelect
{
    public static IQueryable<UserAuthModel> MapToAuthModel(this IQueryable<User> query, int? requestedAppId)
    {
        int currentAppId = AppIdConst.ADM;
        bool isCrossApp = requestedAppId != currentAppId;

        return query.Select(user => new UserAuthModel
        {
            Id = user.Id,
            //Inn = user.Inn,
            UserName = user.UserName,
            FullName = user.Person.FullName,
            IsAdmin = user.Id == 1,
            LanguageId = user.LanguageId,
            LanguageCode = user.Language.Code,
            Pinfl = user.Person.Pinfl,
            PersonId = user.PersonId,
            //CurrentOrganizationId = user.UserOrganizations?.FirstOrDefault()?.Id,
            //Regions = user.Regions,
            Organizations = user.UserOrganizations
                .Where(a => a.StateId == WbStateIdConst.ACTIVE && a.AppId == currentAppId)
                .Select(b => new OrganizationAuthModel
                {
                    Id = b.OrganizationId,
                    FullName = b.Organization.FullName,
                    ShortName = b.Organization.ShortName,
                    RegionId = b.Organization.RegionId,
                    DistrictId = b.Organization.DistrictId,
                    AppId = currentAppId,
                } as IOrganizationAuthModel).ToList(),

            Permissions = user.UserRoles
                .Where(a => a.StateId == WbStateIdConst.ACTIVE && a.Role.AppId == currentAppId)
                .SelectMany(b => b.Role.RolePermissions.Select(c => c.Permission.Code))
                .Distinct(),

            SharedPermissions = user.UserRoles
                .Where(r => r.StateId == WbStateIdConst.ACTIVE)
                .SelectMany(r => r.Role.RolePermissions)
                .Where(rp =>
                    isCrossApp &&
                    rp.Permission.AppId == requestedAppId &&
                    rp.Permission.IsShared &&
                    rp.Permission.SourceAppId == currentAppId
                )
                .Select(rp => rp.Permission.Code)
                .Distinct()
        });
    }
}

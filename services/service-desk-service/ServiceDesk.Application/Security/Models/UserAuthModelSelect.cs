using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.Security;

public static class UserAuthModelSelect
{
    public static IQueryable<UserAuthModel> MapToAuthModel(this IQueryable<User> users)
        => users.Select(a => new UserAuthModel
        {
            Id = a.Id,
            Pinfl = a.Person.Pinfl,
            Inn = a.Person.Inn,
            UserName = a.UserName,
            OrganizationId = a.OrganizationId,
            BranchId = a.BranchId,
            FullName = $"{a.Person.FirstName} {a.Person.LastName} {a.Person.MiddleName}",
            IsAdmin = a.UserRoles.Any(ur => ur.Role.IsAdmin),
            LanguageId = a.LanguageId,
            Permissions = a.UserRoles
                           .Where(a => a.StateId == StateIdConst.ACTIVE)
                           .SelectMany(b => b.Role.RolePermissions.Select(c => c.Permission.Code))
        });

}

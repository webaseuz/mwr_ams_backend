using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Users;

public static class UserSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<User> query,
                                                           GetUserSelectListQuery request,
                                                           IAsyncAppAuthService authService,
                                                           CancellationToken cancellationToken)
    {
        var userInfo = await authService.GetUserAsync();

        if (!userInfo.Permissions.Contains(nameof(PermissionCode.AllUserView)))
            request.BranchId = userInfo.BranchId;

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.Roles.Any())
            query = query.Where(x => x.UserRoles.Any(z => request.Roles.Contains(z.RoleId)));

        var result = await query.Select(a =>
            new UserSelectListItem<int>
            {
                Value = a.Id,
                Text = a.UserName,
                FullName = a.Person.FullName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

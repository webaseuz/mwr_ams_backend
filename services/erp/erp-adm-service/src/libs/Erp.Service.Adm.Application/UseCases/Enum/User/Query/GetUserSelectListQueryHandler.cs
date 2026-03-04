using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetUserSelectListQueryHandler(IApplicationDbContext context, IMainAuthService authService)
    : IRequestHandler<UserSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(UserSelectListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        if (!userInfo.Permissions.Contains(nameof(PermissionCode.AllUserView)))
            request.BranchId = userInfo.BranchId;

        var query = context.Users.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.Roles.Any())
            query = query.Where(x => x.UserRoles.Any(z => request.Roles.Contains(z.RoleId)));

        var result = await query
            .Select(a => new UserSelectListDto
            {
                Value = a.Id,
                Text = a.UserName,
                Id = a.Id,
                FullName = a.Person.FullName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
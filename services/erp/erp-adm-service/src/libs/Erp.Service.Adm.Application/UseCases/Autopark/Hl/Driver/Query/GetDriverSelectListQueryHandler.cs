using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetDriverSelectListQueryHandler(IApplicationDbContext context, IMainAuthService authService)
    : IRequestHandler<DriverSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(DriverSelectListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        if (!userInfo.Permissions.Contains(nameof(AdmPermissionCode.AllViewDriver)))
            request.BranchId = userInfo.BranchId;

        var query = context.Drivers.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.TransportSettingId.HasValue)
            query = query.Where(q => q.Settings.Any(a => a.Id == request.TransportSettingId));

        if (!userInfo.Permissions.Contains(nameof(AdmPermissionCode.DriverBranchView)))
            query = query.Where(q => q.PersonId == userInfo.PersonId);

        if (request.TransportId.HasValue)
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED) &&
                                     q.Settings.OrderByDescending(s => s.Id).FirstOrDefault(s => s.StatusId == StatusIdConst.ACCEPTED).TransportId == request.TransportId);

        var result = await query
            .Select(a => new DriverSelectListDto
            {
                Value = a.Id,
                Text = a.Person.Pinfl + " - " + a.Person.FullName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
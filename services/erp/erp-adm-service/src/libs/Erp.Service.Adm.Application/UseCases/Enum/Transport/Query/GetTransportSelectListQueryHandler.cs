using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using Erp.Core.Constants;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportSelectListQueryHandler(IApplicationDbContext context, IMainAuthService authService)
    : IRequestHandler<TransportSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransportSelectListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        if (!userInfo.Permissions.Contains(nameof(PermissionCode.AllViewTransport)))
            request.BranchId = userInfo.BranchId;

        var query = context.Transports.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (!userInfo.Permissions.Contains(nameof(PermissionCode.TransportBranchView)))
        {
            request.DriverId = null;
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED) &&
                                     q.Settings.OrderByDescending(s => s.Id).FirstOrDefault(s => s.StatusId == StatusIdConst.ACCEPTED).Driver.PersonId == userInfo.PersonId);
        }

        if (request.DriverId.HasValue)
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED) &&
                                     q.Settings.OrderByDescending(s => s.Id).FirstOrDefault(s => s.StatusId == StatusIdConst.ACCEPTED).DriverId == request.DriverId);

        if (request.FromSetting.HasValue && request.FromSetting == true)
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED));

        if (request.FromSetting.HasValue && request.FromSetting == false)
            query = query.Where(q => q.Settings.Count == 0 || q.Settings.All(a => a.StatusId != StatusIdConst.ACCEPTED));

        var result = await query
            .Where(q => q.TransportModel.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TransportSelectListDto
            {
                Value = a.Id,
                OrderCode = a.OrderCode,
                Text = a.StateCode + " " + a.StateNumber + " (" + a.TransportModel.FullName + ")",
                Id = a.Id,
                TransportModelId = a.TransportModelId,
                SettingId = a.Settings.Count > 0 ? a.Settings.Where(s => s.StatusId == StatusIdConst.ACCEPTED).OrderByDescending(s => s.Id).FirstOrDefault().Id : null,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

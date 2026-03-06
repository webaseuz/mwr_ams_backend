using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetFuelCardSelectListQueryHandler(IApplicationDbContext context, IMainAuthService authService)
    : IRequestHandler<FuelCardSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(FuelCardSelectListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        if (!userInfo.Permissions.Contains(nameof(AutoparkPermissionCode.FuelCardViewAll)))
            request.BranchId = userInfo.BranchId;

        if (request.TransportSettingId.HasValue)
        {
            request.TransportId = null;
            request.DriverId = null;
        }

        var query = context.FuelCards.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.TransportSettingId.HasValue)
            query = query.Where(p => p.TransportId.HasValue &&
                                     p.Transport.Settings.Any(a => a.Id == request.TransportSettingId));

        if (request.BranchId.HasValue)
            query = query.Where(p => p.BranchId == request.BranchId);

        if (request.TransportId.HasValue && !request.DriverId.HasValue)
            query = query.Where(p => p.TransportId == request.TransportId);

        if (request.DriverId.HasValue && request.TransportId.HasValue)
        {
            var query1 = query.Where(p => p.DriverId == request.DriverId && p.TransportId == request.TransportId);
            var query2 = query.Where(p => p.TransportId == request.TransportId);
            query = query1.Union(query2);
        }

        var result = await query
            .Select(a => new FuelCardSelectListDto
            {
                Value = a.Id,
                Text = a.CardNumber,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
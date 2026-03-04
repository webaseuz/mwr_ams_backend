using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetDashboardQueryHandler(
    IApplicationDbContext context,
    IMainAuthService authService) : IRequestHandler<DashboardGetQuery, DashboardDto>
{
    public async Task<DashboardDto> Handle(DashboardGetQuery request, CancellationToken cancellationToken)
    {
        var branchId = request.BranchId ?? authService.User.BranchId;

        var drivers = await context.Drivers
            .Where(x => x.BranchId == branchId && x.StateId == WbStateIdConst.ACTIVE)
            .Include(x => x.Branch)
            .ToListAsync(cancellationToken);

        var dto = new DashboardDto
        {
            BranchId = branchId,
            BranchName = drivers.FirstOrDefault()?.Branch?.FullName,
        };

        foreach (var driver in drivers)
        {
            var tracking = await context.PresentTrackingInfos
                .Where(x => x.PersonId == driver.PersonId)
                .FirstOrDefaultAsync(cancellationToken);

            if (tracking is null) continue;

            if (IsInsideBranch(
                Convert.ToDouble(driver.Branch.Latitude),
                Convert.ToDouble(driver.Branch.Longitude),
                (double)tracking.Latitude,
                (double)tracking.Longitude))
            {
                dto.InSidePersonCount++;
                dto.InSidePersonIds.Add(driver.PersonId);
            }
            else
            {
                dto.OutSidePersonCount++;
                dto.OutSidePersonIds.Add(driver.PersonId);
            }
        }

        return dto;
    }

    private static bool IsInsideBranch(double branchLat, double branchLon, double carLat, double carLon)
    {
        const double R = 6371000;
        var latRad1 = branchLat * Math.PI / 180.0;
        var latRad2 = carLat * Math.PI / 180.0;
        var deltaLat = (carLat - branchLat) * Math.PI / 180.0;
        var deltaLon = (carLon - branchLon) * Math.PI / 180.0;

        var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(latRad1) * Math.Cos(latRad2) *
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return (R * c) <= 200;
    }
}
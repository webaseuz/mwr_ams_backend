using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Banks;

public class GetDashboardQueryHandler :
    IRequestHandler<GetDashboardQuery, DashboardDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetDashboardQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper,
                                   IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<DashboardDto> Handle(GetDashboardQuery request,
                                      CancellationToken cancellationToken)
    {
        var dto = new DashboardDto()
        {
            InSidePersonCount = 0,
            OutSidePersonCount = 0,
        };

        if (request.BranchId == null)
            request.BranchId = (await _authService.GetUserAsync()).BranchId;

        var query = await _context.Drivers
                        .IsSoftActive()
                        .Include(b => b.Branch)
                        .Include(b => b.Person)
                        .Where(b => b.BranchId == request.BranchId)
                        .ToListAsync(cancellationToken);

        dto.BranchId = request.BranchId;
        dto.BranchName = query.FirstOrDefault()?.Branch?.FullName;

        foreach (var driver in query)
        {
            var curentPosition = await _context.PresentTrackingInfos
                .Where(b => b.PersonId == driver.PersonId)
                .FirstOrDefaultAsync(cancellationToken);
            if (curentPosition != null)
            {
                if (InSaidBranch(
                    Convert.ToDouble(driver.Branch.Latitude),
                    Convert.ToDouble(driver.Branch.Longitude),
                    Convert.ToDouble(curentPosition.Latitude),
                    Convert.ToDouble(curentPosition.Longitude)))
                {
                    dto.InSidePersonCount += 1;
                    dto.InSidePersonIds.Add(driver.PersonId);
                }
                else
                {
                    dto.OutSidePersonCount += 1;
                    dto.OutSidePersonIds.Add(driver.PersonId);
                }
            }
        }

        return dto;
    }

    private bool InSaidBranch(double BranchLat, double BranchLon, double CarLat, double CarLon)
    {
        const double R = 6371000; // Yer radiusi metrlarda
        var latRad1 = BranchLat * Math.PI / 180.0;
        var latRad2 = CarLat * Math.PI / 180.0;
        var deltaLat = (CarLat - BranchLat) * Math.PI / 180.0;
        var deltaLon = (CarLon - BranchLon) * Math.PI / 180.0;

        var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(latRad1) * Math.Cos(latRad2) *
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        if ((R * c) <= 200)// Masofa (metr)
            return true;
        else
            return false;
    }
}
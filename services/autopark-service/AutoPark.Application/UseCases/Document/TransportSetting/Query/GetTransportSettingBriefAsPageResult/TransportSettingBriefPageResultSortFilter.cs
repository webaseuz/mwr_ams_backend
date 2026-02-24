using AutoPark.Application.Security;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.TransportSettings;

public static class TransportSettingBriefPageResultSortFilter
{
    public static async Task<IQueryable<TransportSettingBriefDto>> SortFilter(
        this IQueryable<TransportSettingBriefDto> query,
        GetTransportSettingBriefAsPageResultQuery request, IAsyncAppAuthService appAuthService)
    {
        await request.Init(appAuthService);

        if (request.HasSearch())
        {
            string target = $"%{request.Search.ToLower()}%";

            query = query.Where(x => EF.Functions.Like(x.ManagerFullName.ToLower(), target) ||
                                     EF.Functions.Like(x.TransportName.ToLower(), target) ||
                                     EF.Functions.Like(x.DriverName.ToLower(), target) ||
                                     EF.Functions.Like(x.TransportModelName.ToLower(), target) ||
                                     EF.Functions.Like(x.DocNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.LicenseNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.PoaNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.FuelCardNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.ResponsiblePersonName.ToLower(), target) ||
                                     EF.Functions.Like(x.StatusName.ToLower(), target)

                                //  x.ManagerFullName.ToLower().Contains(target) ||
                                // x.DocNumber.ToLower().Contains(target) ||
                                // x.TransportName.ToLower().Contains(target) ||
                                // x.DriverName.ToLower().Contains(target) ||
                                // x.LicenseNumber.ToLower().Contains(target) ||
                                // x.PoaNumber.ToLower().Contains(target) ||
                                //// x.MedCertNumber.ToLower().Contains(target) ||
                                // x.ManagerFullName.ToLower().Contains(target) ||
                                // x.FuelCardNumber.ToLower().Contains(target) ||
                                // x.ResponsiblePersonName.ToLower().Contains(target) ||
                                // x.StatusName.ToLower().Contains(target) 
                                );
        }

        query = query.Where(x => x.StatusId != StatusIdConst.DELETED);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.DriverId.HasValue)
            query = query.Where(x => x.DriverId == request.DriverId);

        if (request.HasSort() && request.IsValidSortBy<TransportSettingBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

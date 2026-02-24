using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Extensions;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.FuelCards;

public static class GetTransportBriefPagedResultSortFilter
{
    public static async Task<IQueryable<FuelCardBriefDto>> SortFilter(
        this IQueryable<FuelCardBriefDto> query,
        GetFuelCardBriefPagedResultQuery request, IAsyncAppAuthService appAuthService)
    {
        var userData = await appAuthService.GetUserAsync();

        if (!await appAuthService.HasPermissionAsync(PermissionCode.FuelCardViewAll))
            request.BranchId = userData?.BranchId;

        if (request.HasSearch())
        {
            var target = request.Search.ToLower();

            query = query.Where(x => x.CardNumber.ToLower().Contains(target) ||
                                x.DriverName.ToLower().Contains(target) ||
                                x.TransportModelName.ToLower().Contains(target) ||
                                x.TransportStateNumber.ToLower().Contains(target) ||
                                x.PlasticCardTypeName.ToLower().Contains(target));
        }
            

        if (!request.DriverId.IsNullOrEmptyObject())
            query = query.Where(x => x.DriverId == request.DriverId);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (!request.TransportId.IsNullOrEmptyObject())
            query = query.Where(x => x.TransportId == request.TransportId);

        if (!request.PlasticCardTypeId.IsNullOrEmptyObject())
            query = query.Where(x => x.PlasticCardTypeId == request.PlasticCardTypeId);


        if (request.HasSort() && request.IsValidSortBy<FuelCardBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Extensions;
using System.Linq.Dynamic.Core;


namespace AutoPark.Application.UseCases.Users;

public static class GetUserBriefPagedResultSortFilter
{
    public static async Task<IQueryable<UserBriefDto>> SortFilter(
        this IQueryable<UserBriefDto> query,
        GetUserBriefPagedResultQuery request,
        IAsyncAppAuthService appAuthService)
    {
        await request.Init(appAuthService);

        if (request.RegionId.HasValue)
            query = query.Where(q => q.RegionId == request.RegionId);

        if (request.DistrictId.HasValue)
            query = query.Where(q => q.DistrictId == request.DistrictId);

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (!request.UserName.IsNullOrEmptyObject())
            query = query.Where(q => q.UserName.Contains(request.UserName));

        if (!request.PhoneNumber.IsNullOrEmptyObject())
            query = query.Where(q => q.PhoneNumber.Contains(request.PhoneNumber));

        if (request.StateId.HasValue)
            query = query.Where(q => q.StateId == request.StateId);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.UserName.ToLower().Contains(target) ||
                                     a.PhoneNumber.ToLower().Contains(target) ||
                                     a.StateId.ToString().Contains(target) ||
                                     a.BranchId.ToString().Contains(target) ||
                                     a.RegionId.ToString().Contains(target) ||
                                     a.DistrictId.ToString().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<UserBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;

    }
}
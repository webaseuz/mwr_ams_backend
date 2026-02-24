using Bms.Core.Application;
using System.Linq.Dynamic.Core;


namespace ServiceDesk.Application.UseCases.Users;

public static class GetUserBriefPagedResultSortFilter
{
    public static IQueryable<UserBriefDto> SortFilter(
        this IQueryable<UserBriefDto> query,
        GetUserBriefPagedResultQuery request)
    {

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
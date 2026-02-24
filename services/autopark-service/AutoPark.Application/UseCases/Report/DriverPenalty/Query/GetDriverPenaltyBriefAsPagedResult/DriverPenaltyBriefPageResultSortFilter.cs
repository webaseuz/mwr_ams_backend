using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.DriverPenalties;

public static class DriverPenaltyBriefPageResultSortFilter
{
    public static IQueryable<DriverPenaltyBriefDto> SortFilter(
        this IQueryable<DriverPenaltyBriefDto> query,
        GetDriverPenaltyBriefAsPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => //a.BranchName.ToLower().Contains(target) || 
                                     a.TransportModelName.ToLower().Contains(target) ||
                                     a.RegistrationNumber.ToLower().Contains(target) ||
                                     a.MibCaseStatus.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<DriverPenaltyBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.IsCritical);

        return query;
    }
}

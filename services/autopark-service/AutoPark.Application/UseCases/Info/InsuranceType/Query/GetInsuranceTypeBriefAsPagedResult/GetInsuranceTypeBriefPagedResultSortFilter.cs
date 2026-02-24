using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public static class GetInsuranceTypeBriefPagedResultSortFilter
{
    public static IQueryable<InsuranceTypeBriefDto> SortFilter(
        this IQueryable<InsuranceTypeBriefDto> query,
        GetInsuranceTypeBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.OrderCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<InsuranceTypeBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

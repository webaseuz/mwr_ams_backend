using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.ExpenseLimits;

public static class GetTotalExpenseLimitReportSortFilter
{
    public static IQueryable<TotalExpenseLimitReportListDto> SortFilter(
        this IQueryable<TotalExpenseLimitReportListDto> query,
        GetTotalExpenseLimitReportQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.Driver.ToLower().Contains(target) ||
                                     a.BranchName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<TotalExpenseLimitReportListDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.TransportId);

        return query;
    }
}

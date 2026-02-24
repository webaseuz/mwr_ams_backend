using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Report;

public static class GetTotalExpenseReportSortFilter
{
    public static IQueryable<TotalExpenseReportListDto> SortFilter(
        this IQueryable<TotalExpenseReportListDto> query,
        GetTotalExpenseReportQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.Driver.ToLower().Contains(target) ||
                                     a.BranchName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<TotalExpenseReportListDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.TransportId);

        return query;
    }
}

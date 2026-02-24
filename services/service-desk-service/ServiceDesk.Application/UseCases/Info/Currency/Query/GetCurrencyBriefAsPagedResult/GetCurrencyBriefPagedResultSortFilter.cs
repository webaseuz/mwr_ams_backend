using System.Linq.Dynamic.Core;
using Bms.Core.Application;

namespace ServiceDesk.Application.UseCases.Currencies;

public static class GetCurrencyBriefPagedResultSortFilter
{
    public static IQueryable<CurrencyBriefDto> SortFilter(
        this IQueryable<CurrencyBriefDto> query,
        GetCurrencyBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.Code.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<CurrencyBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

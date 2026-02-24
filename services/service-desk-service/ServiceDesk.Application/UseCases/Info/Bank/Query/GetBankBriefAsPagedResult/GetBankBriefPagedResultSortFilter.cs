using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.Banks;

public static class GetBankBriefPagedResultSortFilter
{
    public static IQueryable<BankBriefDto> SortFilter(
        this IQueryable<BankBriefDto> query,
        GetBankBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.BankCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<BankBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

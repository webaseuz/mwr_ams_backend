using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Info.Contractors;

public static class GetContractorBriefPagedResultSortFilter
{
    public static IQueryable<ContractorBriefDto> SortFilter(
        this IQueryable<ContractorBriefDto> query,
        GetContractorBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<ContractorBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

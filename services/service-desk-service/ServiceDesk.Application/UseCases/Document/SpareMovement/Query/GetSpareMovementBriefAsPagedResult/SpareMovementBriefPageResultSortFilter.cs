using Bms.Core.Application;
using ServiceDesk.Domain.Constants;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.SpareMovements;


public static class SpareMovementBriefPageResultSortFilter
{
    public static IQueryable<SpareMovementBriefDto> SortFilter(
        this IQueryable<SpareMovementBriefDto> query,
		GetSpareMovementBriefPageResultQuery request)
    {
        query = query.Where(q => q.StatusId != StatusIdConst.DELETED);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(x => x.DocNumber.ToLower().Contains(target));
        }

        if (request.BranchId.HasValue)
            query = query.Where(x => x.FromBranchId == request.BranchId || x.ToBranchId == request.BranchId);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.DocDate >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.DocDate <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<SpareMovementBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

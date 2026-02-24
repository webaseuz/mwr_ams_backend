using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.TrackingInfos;

public static class GetTrackingInfoBriefResultSortFilter
{
    public static IQueryable<TrackingInfoBriefDto> SortFilter(
        this IQueryable<TrackingInfoBriefDto> query,
        GetTrackingInfoBriefResultQuery request)
    {
        if (request.FromDate.HasValue)
            query = query.Where(a => a.DateAt >= request.FromDate.Value);

        if (request.ToDate.HasValue)
            query = query.Where(a => a.DateAt <= request.ToDate.Value);

        if (request.PersonId.HasValue)
            query = query.Where(a => a.PersonId == request.PersonId.Value);

        query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

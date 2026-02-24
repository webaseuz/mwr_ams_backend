namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public static class GetPresentTrackingInfoBriefPagedResultSortFilter
{
    public static IQueryable<PresentTrackingInfoBriefDto> SortFilter(
        this IQueryable<PresentTrackingInfoBriefDto> query,
        GetPresentTrackingInfoBriefPagedResultQuery request)
    {
        query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

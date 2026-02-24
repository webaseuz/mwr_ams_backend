using System.Linq.Dynamic.Core;
using Bms.Core.Application;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public static class GetDeviceSpareTypeBriefPagedResultSortFilter
{
    public static IQueryable<DeviceSpareTypeBriefDto> SortFilter(
        this IQueryable<DeviceSpareTypeBriefDto> query,
		GetDeviceSpareTypeBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.OrderCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<DeviceSpareTypeBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

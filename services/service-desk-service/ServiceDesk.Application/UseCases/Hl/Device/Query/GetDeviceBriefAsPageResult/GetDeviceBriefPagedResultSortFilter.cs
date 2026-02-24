using System.Linq.Dynamic.Core;
using Bms.Core.Application;

namespace ServiceDesk.Application.UseCases.Devices;

public static class GetDeviceBriefPagedResultSortFilter
{
    public static IQueryable<DeviceBriefDto> SortFilter(
        this IQueryable<DeviceBriefDto> query,
        GetDeviceBriefPagedResultQuery request)
    {
        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.DeviceTypeId.HasValue)
            query = query.Where(q => q.DeviceTypeId == request.DeviceTypeId);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.UniqueNumber.ToLower().Contains(target) ||
                                     a.SerialNumber.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<DeviceBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

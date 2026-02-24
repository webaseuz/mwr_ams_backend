using AutoPark.Application.Security;
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Transports;

public static class GetTransportBriefPagedResultSortFilter
{
    public static async Task<IQueryable<TransportBriefDto>> SortFilter(
        this IQueryable<TransportBriefDto> query,
        GetTransportBriefPagedResultQuery request, IAsyncAppAuthService appAuthService)
    {
        var userData = await appAuthService.GetUserAsync();


        if (!await appAuthService.HasPermissionAsync(PermissionCode.AllViewTransport))
            request.BranchId = userData?.BranchId;

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(x => x.BranchName.ToLower().Contains(target) ||
                                     x.DepartmentName.ToLower().Contains(target) ||
                                     x.TransportModelName.ToLower().Contains(target) ||
                                     x.OrderCode.ToLower().Contains(target) ||
                                     x.StateNumber.ToLower().Contains(target) ||
                                     x.TransportUseTypeName.ToLower().Contains(target) ||
                                     x.TransportBrandName.ToLower().Contains(target) ||
                                     x.TransportColorName.ToLower().Contains(target) 
                                     );
        }

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);


        if (request.HasSort() && request.IsValidSortBy<TransportBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

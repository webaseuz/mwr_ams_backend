using Bms.Core.Application;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain.Constants;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.ServiceApplications;


public static class ServiceApplicationBriefPageResultSortFilter
{
    public async static Task<IQueryable<ServiceApplicationBriefDto>> SortFilter(
        this IQueryable<ServiceApplicationBriefDto> query,
        GetServiceApplicationBriefPageResultQuery request,
        IAsyncAppAuthService authService)
    {
        var userInfo = await authService.GetUserAsync();

        query = query.Where(x => x.StatusId != StatusIdConst.DELETED);

        if (!await authService.HasPermissionAsync(PermissionCode.AllViewServiceApplication))
            request.BranchId = userInfo?.BranchId;

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(x => x.DocNumber.ToLower().Contains(target));
        }

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.DocDate >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.DocDate <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<ServiceApplicationBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

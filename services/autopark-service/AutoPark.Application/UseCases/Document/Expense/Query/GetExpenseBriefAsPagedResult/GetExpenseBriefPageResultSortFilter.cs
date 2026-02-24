using AutoPark.Application.Security;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Expenses;

public static class GetExpenseBriefPageResultSortFilter
{
    public async static Task<IQueryable<ExpenseBriefDto>> SortFilter(
        this IQueryable<ExpenseBriefDto> query,
        GetExpenseBriefPageResultQuery request,
        IAsyncAppAuthService authService,
        IReadEfCoreContext context)
    {
        var userInfo = await authService.GetUserAsync();
        var hasViewAll = userInfo.Permissions.Contains(nameof(PermissionCode.AllViewExpense));
        if (!hasViewAll)
        {
            var driver = await context.Drivers.FirstOrDefaultAsync(x => x.PersonId == userInfo.PersonId);
            query = query.Where(x => x.StatusId != StatusIdConst.DELETED && x.DriverId == driver.Id);

        }
        if (!await authService.HasPermissionAsync(PermissionCode.AllViewExpense))
            request.BranchId = userInfo?.BranchId;

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.DocNumber.ToLower().Contains(target) ||
                                     a.DriverName.ToLower().Contains(target) ||
                                    // a.TransportInfo.ToLower().Contains(target)) //||
                                    a.Id.ToString().ToLower().Contains(target))
                ;
        }

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<ExpenseBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

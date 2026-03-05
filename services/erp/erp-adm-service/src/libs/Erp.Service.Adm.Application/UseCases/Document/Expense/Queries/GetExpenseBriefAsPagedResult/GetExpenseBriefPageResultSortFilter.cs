using System.Linq.Dynamic.Core;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Application;
using Erp.Service.Adm.Models;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public static class GetExpenseBriefPageResultSortFilter
{
    public async static Task<IQueryable<ExpenseBriefDto>> SortFilter(
        this IQueryable<ExpenseBriefDto> query,
        ExpenseGetBriefPageResultQuery request,
        IMainAuthService authService,
        IApplicationDbContext context)
    {
        var userInfo = authService.User;
        var hasViewAll = userInfo.Permissions.Contains(nameof(AdmPermissionCode.AllViewExpense));
        if (!hasViewAll)
        {
            var driver = await context.Drivers.FirstOrDefaultAsync(x => x.PersonId == userInfo.PersonId);
            query = query.Where(x => x.StatusId != StatusIdConst.DELETED && x.DriverId == driver.Id);

        }
        if (!authService.HasPermission(nameof(AdmPermissionCode.AllViewExpense)))
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

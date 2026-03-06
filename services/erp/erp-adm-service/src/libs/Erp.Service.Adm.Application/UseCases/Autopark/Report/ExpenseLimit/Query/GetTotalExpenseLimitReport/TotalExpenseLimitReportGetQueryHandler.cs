using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TotalExpenseLimitReportGetQueryHandler(
    IApplicationDbContext context) : IRequestHandler<TotalExpenseLimitReportGetQuery, WbPagedResult<TotalExpenseLimitReportListDto>>
{
    public async Task<WbPagedResult<TotalExpenseLimitReportListDto>> Handle(TotalExpenseLimitReportGetQuery request, CancellationToken cancellationToken)
    {
        var query = context.Database
            .SqlQuery<TotalExpenseLimitReportListDto>(
                $"SELECT transport_id as \"TransportId\", driver_id as \"DriverId\", branch_id as \"BranchId\", branch_name as \"BranchName\", transport_info as \"TransportInfo\", driver as \"Driver\", total_sum as \"TotalSum\", is_over_limit as \"IsOverLimit\" FROM public.get_total_expense_over_limit({request.BranchId}, {request.TransportId}, {request.DriverId}, {request.FromDate}, {request.ToDate})");

        if (request.HasSearch())
        {
            var target = request.Search!.ToLower();
            query = query.Where(x => x.Driver.ToLower().Contains(target) ||
                                     x.BranchName.ToLower().Contains(target));
        }

        if (request.HasSort())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.TransportId);

        return await query.AsPagedResultAsync(request);
    }
}

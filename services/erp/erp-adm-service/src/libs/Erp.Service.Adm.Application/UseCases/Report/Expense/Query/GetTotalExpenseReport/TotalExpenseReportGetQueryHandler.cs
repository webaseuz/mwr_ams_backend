using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TotalExpenseReportGetQueryHandler(
    IApplicationDbContext context) : IRequestHandler<TotalExpenseReportGetQuery, WbPagedResult<TotalExpenseReportListDto>>
{
    public async Task<WbPagedResult<TotalExpenseReportListDto>> Handle(TotalExpenseReportGetQuery request, CancellationToken cancellationToken)
    {
        var query = context.Database
            .SqlQuery<TotalExpenseReportListDto>(
                $"SELECT transport_id as \"TransportId\", driver_id as \"DriverId\", branch_id as \"BranchId\", branch_name as \"BranchName\", transport_info as \"TransportInfo\", driver as \"Driver\", total_sum as \"TotalSum\" FROM public.get_total_expense({request.BranchId}, {request.TransportId}, {request.DriverId}, {request.FromDate}, {request.ToDate})");

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

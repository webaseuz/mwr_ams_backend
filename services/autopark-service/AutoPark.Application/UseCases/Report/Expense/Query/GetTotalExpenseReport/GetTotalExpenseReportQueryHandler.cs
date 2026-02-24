using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Report;

public class GetTotalExpenseReportQueryHandler :
    IRequestHandler<GetTotalExpenseReportQuery, PagedResult<TotalExpenseReportListDto>>
{
    private readonly IReadEfCoreContext _context;

    public GetTotalExpenseReportQueryHandler(
        IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<TotalExpenseReportListDto>> Handle(
        GetTotalExpenseReportQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _context.GetTotalExpenseReport(
            request.BranchId,
            request.TransportId,
            request.DriverId,
            request.FromDate,
            request.ToDate
            ).SortFilter(request).AsPagedResultAsync(request);

        return result;
    }
}

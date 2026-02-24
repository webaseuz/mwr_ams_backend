using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.ExpenseLimits;

public class GetTotalExpenseLimitReportQueryHandler :
    IRequestHandler<GetTotalExpenseLimitReportQuery, PagedResult<TotalExpenseLimitReportListDto>>
{
    private readonly IReadEfCoreContext _context;

    public GetTotalExpenseLimitReportQueryHandler(
        IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<TotalExpenseLimitReportListDto>> Handle(
        GetTotalExpenseLimitReportQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _context.GetTotalExpenseLimitReport(
            request.BranchId,
            request.TransportId,
            request.DriverId,
            request.FromDate,
            request.ToDate
            ).SortFilter(request).AsPagedResultAsync(request);

        return result;
    }
}

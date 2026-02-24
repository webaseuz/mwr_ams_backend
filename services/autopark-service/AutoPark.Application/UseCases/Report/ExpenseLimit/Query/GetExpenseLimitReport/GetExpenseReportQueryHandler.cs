using AutoPark.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.ExpenseLimits;

public class GetExpenseReportQueryHandler :
    IRequestHandler<GetExpenseLimitReportQuery, List<ExpenseLimitReportListDto>>
{
    private readonly IReadEfCoreContext _context;

    public GetExpenseReportQueryHandler(
        IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<List<ExpenseLimitReportListDto>> Handle(
        GetExpenseLimitReportQuery request,
        CancellationToken cancellationToken)
    {
        var res = await _context.GetExpenseLimitReport(
            request.BranchId,
            request.TransportId,
            request.DriverId,
            request.FromDate,
            request.ToDate
            ).
            Select(x => new ExpenseLimitReportListDto()
            {
                ExpensePrice = x.ExpensePrice,
                ExpenseType = _context.ExpenseTypes.Where(z => z.Id == x.ExpenseTypeId).FirstOrDefault().Translates.AsQueryable()
                              .FirstOrDefault(ExpenseTypeTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                              _context.ExpenseTypes.Where(z => z.Id == x.ExpenseTypeId).FirstOrDefault().FullName,
                MonthlyLimit = x.MonthlyLimit,
                IsOverLimit = x.IsOverLimit,
            }).ToListAsync();

        return res;
    }
}

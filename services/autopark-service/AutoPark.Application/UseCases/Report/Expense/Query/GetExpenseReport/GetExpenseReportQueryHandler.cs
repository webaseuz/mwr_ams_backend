using AutoPark.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Report;

public class GetExpenseReportQueryHandler :
    IRequestHandler<GetExpenseReportQuery, List<ExpenseReportListDto>>
{
    private readonly IReadEfCoreContext _context;

    public GetExpenseReportQueryHandler(
        IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<List<ExpenseReportListDto>> Handle(
        GetExpenseReportQuery request,
        CancellationToken cancellationToken)
    {
        var res = await _context.GetExpenseReport(
            request.BranchId,
            request.TransportId,
            request.DriverId,
            request.FromDate,
            request.ToDate
            ).
            Select(x => new ExpenseReportListDto()
            {
                Type = x.Brand,
                ExpenseDate = x.ExpenseDate,
                ExpensePrice = x.ExpensePrice,
                ExpenseType = _context.ExpenseTypes.Where(z => z.Id == x.ExpenseTypeId).FirstOrDefault().Translates.AsQueryable()
                              .FirstOrDefault(ExpenseTypeTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                              _context.ExpenseTypes.Where(z => z.Id == x.ExpenseTypeId).FirstOrDefault().FullName,
                Price = x.Price,
                Quantity = x.Quantity,
            }).ToListAsync();

        return res;
    }
}

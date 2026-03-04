using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class ExpenseReportGetQueryHandler(
    IApplicationDbContext context,
    ICultureHelper cultureHelper) : IRequestHandler<ExpenseReportGetQuery, List<ExpenseReportListDto>>
{
    public async Task<List<ExpenseReportListDto>> Handle(ExpenseReportGetQuery request, CancellationToken cancellationToken)
    {
        var cultureId = cultureHelper.CurrentCulture.Id;

        var result = await context.Database
            .SqlQuery<ExpenseReportRawResult>(
                $"SELECT expense_date, expense_type_id, brand, quantity, price, expense_price FROM public.get_expense({request.BranchId}, {request.TransportId}, {request.DriverId}, {request.FromDate}, {request.ToDate})")
            .ToListAsync(cancellationToken);

        var expenseTypeIds = result.Select(x => x.expense_type_id).Distinct().ToList();
        var expenseTypes = await context.ExpenseTypes
            .Where(et => expenseTypeIds.Contains(et.Id))
            .Select(et => new
            {
                et.Id,
                et.FullName,
                TranslateText = et.Translates
                    .Where(t => t.LanguageId == cultureId)
                    .Select(t => t.TranslateText)
                    .FirstOrDefault()
            })
            .ToListAsync(cancellationToken);

        return result.Select(x => new ExpenseReportListDto
        {
            ExpenseDate = x.expense_date,
            Type = x.brand,
            Quantity = x.quantity,
            Price = x.price,
            ExpensePrice = x.expense_price,
            ExpenseType = expenseTypes.FirstOrDefault(et => et.Id == x.expense_type_id)?.TranslateText
                          ?? expenseTypes.FirstOrDefault(et => et.Id == x.expense_type_id)?.FullName
        }).ToList();
    }

    private class ExpenseReportRawResult
    {
        public DateTime expense_date { get; set; }
        public int expense_type_id { get; set; }
        public string brand { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public decimal expense_price { get; set; }
    }
}

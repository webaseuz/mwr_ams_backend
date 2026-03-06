using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class ExpenseLimitReportGetQueryHandler(
    IApplicationDbContext context,
    ICultureHelper cultureHelper) : IRequestHandler<ExpenseLimitReportGetQuery, List<ExpenseLimitReportListDto>>
{
    public async Task<List<ExpenseLimitReportListDto>> Handle(ExpenseLimitReportGetQuery request, CancellationToken cancellationToken)
    {
        var cultureId = cultureHelper.CurrentCulture.Id;

        var result = await context.Database
            .SqlQuery<ExpenseLimitRawResult>(
                $"SELECT expense_type_id, expense_price, monthly_limit, is_over_limit FROM public.get_expense_over_limit({request.BranchId}, {request.TransportId}, {request.DriverId}, {request.FromDate}, {request.ToDate})")
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

        return result.Select(x => new ExpenseLimitReportListDto
        {
            ExpensePrice = x.expense_price,
            MonthlyLimit = x.monthly_limit,
            IsOverLimit = x.is_over_limit,
            ExpenseType = expenseTypes.FirstOrDefault(et => et.Id == x.expense_type_id)?.TranslateText
                          ?? expenseTypes.FirstOrDefault(et => et.Id == x.expense_type_id)?.FullName
        }).ToList();
    }

    private class ExpenseLimitRawResult
    {
        public int expense_type_id { get; set; }
        public decimal expense_price { get; set; }
        public decimal monthly_limit { get; set; }
        public bool is_over_limit { get; set; }
    }
}

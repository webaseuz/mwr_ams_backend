using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetExpenseSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<ExpenseSelectListQuery, WbSelectList<long>>
{
    public async Task<WbSelectList<long>> Handle(ExpenseSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Expenses
            .Select(a => new ExpenseSelectListDto
            {
                Value = a.Id,
                Text = a.ContractorName,
                OrderCode = a.DocNumber,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

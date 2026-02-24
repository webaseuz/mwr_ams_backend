using AutoPark.Application.UseCases.Drivers;
using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public static class ExpenseSelectList
{
    public static async Task<SelectList<long>> AsSelectList(this IQueryable<Expense> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new DriverSelectListItem<long>
            {
                Value = a.Id,
                Text = a.ContractorName,
                OrderCode = a.DocNumber
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

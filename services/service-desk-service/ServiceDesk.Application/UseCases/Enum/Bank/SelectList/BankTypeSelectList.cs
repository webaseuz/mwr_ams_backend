using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Banks;

public static class BankTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Bank> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new BankTypeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
				BankCode = a.BankCode,
			})
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

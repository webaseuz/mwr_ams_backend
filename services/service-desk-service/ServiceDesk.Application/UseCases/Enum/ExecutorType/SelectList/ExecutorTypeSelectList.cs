using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.ExecutorTypes;

public static class ExecutorTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<ExecutorType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new ExecutorTypeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
			})
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

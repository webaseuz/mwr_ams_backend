using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Contractors;

public static class ContractorTypeSelectList
{
    public static async Task<SelectList<long>> AsSelectList(this IQueryable<Contractor> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<long>
            {
                Value = a.Id,
                Text = a.ShortName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

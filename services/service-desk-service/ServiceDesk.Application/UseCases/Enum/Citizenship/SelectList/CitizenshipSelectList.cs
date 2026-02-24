using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Citizenships;

public static class CitizenshipSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Citizenship> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.WbCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

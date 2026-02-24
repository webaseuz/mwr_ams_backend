using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Countries;

public static class CountryTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Country> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

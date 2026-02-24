using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Citizenships;

public static class CitizenshipSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Citizenship> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new CitizenshipSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.WbCode,
                IsCitizenship = a.IsCitizenship

            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

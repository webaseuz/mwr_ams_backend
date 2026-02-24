using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Enum.PlasticCardTypes;

public static class PlasticCardTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<PlasticCardType> query,
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

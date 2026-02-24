using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Regions;

public static class RegionSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Region> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

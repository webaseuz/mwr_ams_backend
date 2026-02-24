using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TireSizes;

public static class TireSizeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<TireSize> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query
            .IsSoftActive()
            .Select(a =>
            new TireSizeSelectListItem<int>
            {
                Value = a.Id,
                Width = a.Width,
                Height = a.Height,
                Diameter = a.Radius,
                Text = $"{a.Height}/{a.Width} R{a.Radius}".Replace(".00", "")
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}


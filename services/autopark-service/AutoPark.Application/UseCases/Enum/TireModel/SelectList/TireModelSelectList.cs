using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TireModels;

public static class TireModelSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<TireModel> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query
            .IsSoftActive()
            .Select(a =>
            new TireModelSelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
                FullName = a.FullName
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

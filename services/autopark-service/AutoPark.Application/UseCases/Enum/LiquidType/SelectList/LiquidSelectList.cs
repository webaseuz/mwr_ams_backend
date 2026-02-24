using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Enums;

public static class LiquidSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<LiquidType> query,
                                                              CancellationToken cancellationToken)
    {
        var result = await query
            .IsSoftActive()
            .Select(a =>
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

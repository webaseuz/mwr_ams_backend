using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.BatteryTypes;

public static class BatteryTypeTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<BatteryType> query,
                                                               GetBatteryTypeSelectListQuery request,
                                                               CancellationToken cancellationToken)
    {
        var result = await query
            .IsSoftActive()
            .Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

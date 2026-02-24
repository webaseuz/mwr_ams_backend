using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public static class DeviceSpareTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<DeviceSpareType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new DeviceSpareTypeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode,
                Nomenclature = a.Nomenclature
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

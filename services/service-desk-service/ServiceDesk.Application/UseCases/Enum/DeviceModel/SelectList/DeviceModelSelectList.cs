using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public static class DeviceModelSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<DeviceModel> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new DeviceModelSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

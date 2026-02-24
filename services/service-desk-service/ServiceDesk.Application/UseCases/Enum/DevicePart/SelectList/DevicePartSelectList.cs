using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public static class DevicePartSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<DevicePart> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new DevicePartSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

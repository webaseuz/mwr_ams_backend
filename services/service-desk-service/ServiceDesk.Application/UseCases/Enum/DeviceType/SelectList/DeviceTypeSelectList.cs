using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public static class DeviceTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<DeviceType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.IsSoftActive().Select(a =>
            new DeviceTypeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

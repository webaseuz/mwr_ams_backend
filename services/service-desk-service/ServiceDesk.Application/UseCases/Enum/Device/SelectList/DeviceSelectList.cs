using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public static class DeviceSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Device> query,
                                                            GetDeviceSelectListQuery request,
                                                               CancellationToken cancellationToken)
    {
        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.DeviceTypeId.HasValue)
            query = query.Where(q => q.DeviceTypeId == request.DeviceTypeId);

        var result = await query.Select(a =>
            new DeviceSelectListItem<int>
            {
                Value = a.Id,
                Text = $"{a.DeviceModel.FullName}-{a.UniqueNumber}",
                OrderCode = a.SerialNumber,
                SerialNumber = a.SerialNumber,
                ManufacturerId = a.ManufacturerId
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

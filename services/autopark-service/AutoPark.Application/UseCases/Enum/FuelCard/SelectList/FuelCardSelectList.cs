using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.FuelCards;

public static class FuelCardSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<FuelCard> query,
                                                           GetFuelCardSelectListQuery request,
                                                           CancellationToken cancellationToken)
    {
        if (request.TransportSettingId.HasValue)
            query = query.Where(p => p.TransportId.HasValue &&
                                     p.Transport.Settings.Any(a => a.Id == request.TransportSettingId));

        if (request.BranchId.HasValue)
            query = query.Where(p => p.BranchId == request.BranchId);

        if (!request.TransportId.IsNullOrEmptyObject() && request.DriverId.IsNullOrEmptyObject())
            query = query.Where(p => p.TransportId == request.TransportId);

        if (!request.DriverId.IsNullOrEmptyObject() && !request.DriverId.IsNullOrEmptyObject())
        {
            var query1 = query.Where(p => p.DriverId == request.DriverId && p.TransportId == request.TransportId);
            var query2 = query.Where(p => p.TransportId == request.TransportId);

            query = query1.Union(query2);
        }

        var result = await query
            .IsSoftActive()
            .Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.CardNumber,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

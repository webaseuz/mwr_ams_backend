using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportModels;

public static class TransportModelSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<TransportModel> query,
                                                                GetTransportModelSelectListQuery request,
                                                                CancellationToken cancellationToken)
    {
        if (request.TransportBrandId.HasValue)
            query = query.Where(q => q.TransportBrandId == request.TransportBrandId);

        var result = await query
            .IsSoftActive()
            .Select(a =>
            new TransportModelSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode,
                TransportTypeId = a.TransportTypeId,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

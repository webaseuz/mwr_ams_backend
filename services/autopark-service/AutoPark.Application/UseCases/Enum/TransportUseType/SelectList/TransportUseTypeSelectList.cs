using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public static class TransportUseTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<TransportUseType> query,
                                                                GetTransportUseTypeSelectListQuery request,
                                                                CancellationToken cancellationToken)
    {
        var result = await query
            .IsSoftActive()
            .Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

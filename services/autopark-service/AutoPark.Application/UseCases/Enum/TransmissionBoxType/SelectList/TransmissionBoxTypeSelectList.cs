using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransmissionBoxTypes;

public static class TransmissionBoxTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<TransmissionBoxType> query,
                                                               GetTransmissionBoxTypeSelectListQuery request,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.OilModels;

public static class OilModelSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<OilModel> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query
            .IsSoftActive()
            .Select(a =>
            new OilModelSelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
                FullName = a.FullName
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

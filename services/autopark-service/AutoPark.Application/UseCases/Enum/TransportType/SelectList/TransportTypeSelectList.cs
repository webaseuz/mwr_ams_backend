using AutoPark.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Enum.TransportTypes;

public static class TransportTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<TransportType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.Translates.AsQueryable()
                    .FirstOrDefault(TransportTypeTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? a.FullName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

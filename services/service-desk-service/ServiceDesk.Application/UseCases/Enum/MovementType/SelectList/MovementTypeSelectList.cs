using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.MovementTypes;

public static class MovementTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<MovementType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.Translates.AsQueryable().FirstOrDefault(MovementTypeTranslate.GetExpr(TranslateColumn.short_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? a.ShortName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

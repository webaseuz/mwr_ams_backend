using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;

namespace ServiceDesk.Application.UseCases.Enum.Genders;

public static class GenderSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Gender> query,
                                                           CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.Translates.AsQueryable().FirstOrDefault(GenderTranslate.GetExpr(TranslateColumn.short_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? a.ShortName
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

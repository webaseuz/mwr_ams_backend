using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;

namespace ServiceDesk.Application.UseCases.BaseDeviceTypes;

public static class BaseDeviceTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<BaseDeviceType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new BaseDeviceTypeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.Translates.AsQueryable()
                    .FirstOrDefault(BaseDeviceTypeTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? a.FullName,
                OrderCode = a.OrderCode,
			})
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}


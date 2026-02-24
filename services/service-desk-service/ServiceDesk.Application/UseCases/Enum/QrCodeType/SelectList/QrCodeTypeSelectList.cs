using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Enum.QrCodeTypes;

public static class QrCodeTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<QrCodeType> query,
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

using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.ApplicationPurposes;

public static class ApplicationPurposeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<ApplicationPurpose> query,
                                                               CancellationToken cancellationToken)
    {
        
        var result = await query.Select(a =>
            new ApplicationPurposeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
			})
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

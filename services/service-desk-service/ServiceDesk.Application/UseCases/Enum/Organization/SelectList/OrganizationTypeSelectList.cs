using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public static class OrganizationTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Organization> query,
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

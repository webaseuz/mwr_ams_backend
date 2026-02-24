using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Roles;

public static class RoleSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Role> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public static class ServiceTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<ServiceType> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new ServiceTypeSelectListItem<int>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

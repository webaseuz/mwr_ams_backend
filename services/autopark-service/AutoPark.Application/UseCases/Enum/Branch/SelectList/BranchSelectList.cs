using AutoPark.Domain;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Branches;

public static class BranchSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Branch> query,
                                                               GetBranchSelectListQuery request,
                                                               CancellationToken cancellationToken)
    {
        if (request.RegionId.HasValue)
            query = query.Where(q => q.RegionId == request.RegionId);

        if (request.OrganizationId.HasValue)
            query = query.Where(a => a.OrganizationId == request.OrganizationId);

        var result = await query
            .IsSoftActive()
            .Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

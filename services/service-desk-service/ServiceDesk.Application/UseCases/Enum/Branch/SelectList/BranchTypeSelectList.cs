using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Branches;

public static class BranchTypeSelectList
{
	public static async Task<SelectList<int>> AsSelectList(this IQueryable<Branch> query,
                                                               GetBranchSelectListQuery request,
															   IAsyncAppAuthService appAuthService,
															   CancellationToken cancellationToken)
    {
        if (request.RegionId.HasValue)
            query = query.Where(q => q.RegionId == request.RegionId);

        if (request.OrganizationId.HasValue)
            query = query.Where(a => a.OrganizationId == request.OrganizationId);

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

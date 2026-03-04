using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetBranchSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<BranchSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(BranchSelectListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Branches.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.RegionId.HasValue)
            query = query.Where(q => q.RegionId == request.RegionId);

        if (request.OrganizationId.HasValue)
            query = query.Where(a => a.OrganizationId == request.OrganizationId);

        var result = await query
            .Select(a => new BranchSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetDistrictSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<DistrictSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(DistrictSelectListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Districts.AsQueryable();

        if (request.RegionId.HasValue)
            query = query.Where(x => x.RegionId == request.RegionId.Value);

        var result = await query
            .Select(a => new DistrictSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
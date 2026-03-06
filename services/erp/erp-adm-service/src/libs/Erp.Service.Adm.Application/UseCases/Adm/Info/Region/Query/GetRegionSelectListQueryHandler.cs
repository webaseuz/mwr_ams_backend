using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetRegionSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<RegionSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(RegionSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Regions
            .Where(x => !request.CountryId.HasValue || x.CountryId == request.CountryId)
            .Select(a => new RegionSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
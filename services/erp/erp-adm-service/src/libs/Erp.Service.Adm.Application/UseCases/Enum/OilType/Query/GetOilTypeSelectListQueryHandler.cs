using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetOilTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<OilTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(OilTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.OilTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new OilTypeSelectListDto
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
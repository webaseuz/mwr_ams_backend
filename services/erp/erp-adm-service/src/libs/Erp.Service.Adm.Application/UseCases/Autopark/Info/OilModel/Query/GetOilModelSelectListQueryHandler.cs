using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetOilModelSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<OilModelSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(OilModelSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.OilModels
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Where(x => !request.OilTypeId.HasValue || x.OilTypeId == request.OilTypeId.Value)
            .Select(a => new OilModelSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
                Id = a.Id,
                FullName = a.FullName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
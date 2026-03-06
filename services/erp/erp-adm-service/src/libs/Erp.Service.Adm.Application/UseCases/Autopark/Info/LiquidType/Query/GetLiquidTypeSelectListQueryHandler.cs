using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetLiquidTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<LiquidTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(LiquidTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.LiquidTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new LiquidTypeSelectListDto
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
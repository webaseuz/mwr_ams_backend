using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetBatteryTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<BatteryTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(BatteryTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.BatteryTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new BatteryTypeSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
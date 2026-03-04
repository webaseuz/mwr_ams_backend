using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class PositionSelectListQueryHandler(
    IApplicationDbContext context) : IRequestHandler<PositionSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(PositionSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Positions
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new PositionSelectListDto { Value = a.Id, Text = a.ShortName, Id = a.Id })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTireModelSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TireModelSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TireModelSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TireModels
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TireModelSelectListDto
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
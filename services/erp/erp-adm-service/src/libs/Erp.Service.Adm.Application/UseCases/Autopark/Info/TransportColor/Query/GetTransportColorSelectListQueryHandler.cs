using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportColorSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransportColorSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransportColorSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TransportColors
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TransportColorSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
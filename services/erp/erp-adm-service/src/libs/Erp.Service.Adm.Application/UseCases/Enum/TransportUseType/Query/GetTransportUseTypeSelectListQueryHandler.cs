using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportUseTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransportUseTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransportUseTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TransportUseTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TransportUseTypeSelectListDto
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
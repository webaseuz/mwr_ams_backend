using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportBrandSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransportBrandSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransportBrandSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TransportBrands
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TransportBrandSelectListDto
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
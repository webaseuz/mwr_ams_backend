using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportModelSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransportModelSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransportModelSelectListQuery request, CancellationToken cancellationToken)
    {
        var query = context.TransportModels.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.TransportBrandId.HasValue)
            query = query.Where(q => q.TransportBrandId == request.TransportBrandId);

        var result = await query
            .Select(a => new TransportModelSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode,
                Id = a.Id,
                TransportTypeId = a.TransportTypeId,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
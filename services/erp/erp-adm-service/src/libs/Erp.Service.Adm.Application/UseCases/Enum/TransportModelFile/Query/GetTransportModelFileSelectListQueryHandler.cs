using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportModelFileSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransportModelFileSelectListQuery, WbSelectList<Guid>>
{
    public async Task<WbSelectList<Guid>> Handle(TransportModelFileSelectListQuery request, CancellationToken cancellationToken)
    {
        var query = context.TransportModelFiles.AsQueryable();

        if (request.TransportModelId != 0)
            query = query.Where(x => x.TransportModelId == request.TransportModelId);

        if (request.TransportColorId != 0)
            query = query.Where(x => x.TransportColorId == request.TransportColorId);

        var result = await query
            .Select(a => new TransportModelFileSelectListDto
            {
                Value = a.Id,
                Text = a.FileName,
                Id = a.Id,
                TransportModelId = a.TransportModelId,
                TransportColorId = a.TransportColorId,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

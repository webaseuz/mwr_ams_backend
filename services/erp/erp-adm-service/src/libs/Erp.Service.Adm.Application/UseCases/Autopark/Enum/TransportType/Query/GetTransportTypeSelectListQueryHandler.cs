using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransportTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransportTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TransportTypes
            .Select(a => new TransportTypeSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

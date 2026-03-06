using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransmissionBoxTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TransmissionBoxTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TransmissionBoxTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TransmissionBoxTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TransmissionBoxTypeSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
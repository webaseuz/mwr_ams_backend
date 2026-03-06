using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetQrCodeStateSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<QrCodeStateSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(QrCodeStateSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.QrCodeStates
            .Select(a => new QrCodeStateSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

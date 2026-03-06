using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetQrCodeTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<QrCodeTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(QrCodeTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.QrCodeTypes
            .Select(a => new QrCodeTypeSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

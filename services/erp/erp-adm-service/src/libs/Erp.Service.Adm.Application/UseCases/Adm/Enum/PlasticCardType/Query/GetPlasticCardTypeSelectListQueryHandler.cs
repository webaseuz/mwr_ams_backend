using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetPlasticCardTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<PlasticCardTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(PlasticCardTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.PlasticCardTypes
            .Select(a => new PlasticCardTypeSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetContractorSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<ContractorSelectListQuery, WbSelectList<long>>
{
    public async Task<WbSelectList<long>> Handle(ContractorSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Contractors
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new ContractorSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetInsuranceTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<InsuranceTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(InsuranceTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.InsuranceTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new InsuranceTypeSelectListDto
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
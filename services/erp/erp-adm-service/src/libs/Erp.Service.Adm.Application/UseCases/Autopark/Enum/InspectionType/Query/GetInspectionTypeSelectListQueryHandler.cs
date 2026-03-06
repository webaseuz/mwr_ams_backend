using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetInspectionTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<InspectionTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(InspectionTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.InspectionTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new InspectionTypeSelectListDto
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
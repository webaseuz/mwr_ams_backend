using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetCitizenshipSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<CitizenshipSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(CitizenshipSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Citizenships
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new CitizenshipSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.WbCode,
                Id = a.Id,
                IsCitizenship = a.IsCitizenship,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTireSizeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<TireSizeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(TireSizeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.TireSizes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new TireSizeSelectListDto
            {
                Value = a.Id,
                Text = $"{a.Height}/{a.Width} R{a.Radius}".Replace(".00", ""),
                Id = a.Id,
                Width = a.Width,
                Height = a.Height,
                Diameter = a.Radius,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
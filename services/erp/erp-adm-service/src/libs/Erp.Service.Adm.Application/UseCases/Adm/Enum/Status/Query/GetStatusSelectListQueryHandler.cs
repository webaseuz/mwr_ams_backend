using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetStatusSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<StatusSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(StatusSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Statuses
            .Select(a => new StatusSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
                ShortName = a.ShortName,
                FullName = a.FullName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

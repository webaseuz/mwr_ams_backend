using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetStateSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<StateSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(StateSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.States
            .Select(a => new StateSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
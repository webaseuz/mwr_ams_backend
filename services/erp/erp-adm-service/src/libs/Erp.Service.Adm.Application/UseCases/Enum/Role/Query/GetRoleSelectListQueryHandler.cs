using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetRoleSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<RoleSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(RoleSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Roles
            .Select(a => new RoleSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
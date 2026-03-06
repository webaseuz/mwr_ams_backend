using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetOrganizationSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<OrganizationSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(OrganizationSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Organizations
            .Select(a => new OrganizationSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

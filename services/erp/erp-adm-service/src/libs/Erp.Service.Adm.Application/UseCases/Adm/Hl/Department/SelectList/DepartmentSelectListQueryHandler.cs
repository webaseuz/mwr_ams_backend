using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DepartmentSelectListQueryHandler(
    IApplicationDbContext context) : IRequestHandler<DepartmentSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(DepartmentSelectListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Departments.Where(x => x.StateId == WbStateIdConst.ACTIVE);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId.Value);

        var result = await query
            .Select(a => new DepartmentSelectListDto { Value = a.Id, Text = a.ShortName, Id = a.Id })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

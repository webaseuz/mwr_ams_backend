using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Core.Service.Domain.Entities.Sys;
using Erp.Service.Adm.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetPermissionSelectListQueryHandler(IApplicationDbContext context, IPermissionResolver permissionResolver)
    : IRequestHandler<PermissionSelectListQuery, IEnumerable<PermissionGroupSelectListDto>>
{
    public async Task<IEnumerable<PermissionGroupSelectListDto>> Handle(PermissionSelectListQuery request, CancellationToken cancellationToken)
    {
        await permissionResolver.InitIfNeededAsync();

        return context.Permissions
            .Include(a => a.Translates)
            .Include(a => a.SubGroup)
            .Include(a => a.SubGroup.Group)
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .AsEnumerable()
            .GroupBy(a => a.SubGroup.Group, (groupKey, groupResults) => new PermissionGroupSelectListDto
            {
                Id = groupKey.Id,
                ShortName = groupKey.ShortName,
                FullName = groupKey.FullName,
                SubGroups = groupResults.GroupBy(b => b.SubGroup, (subGroupKey, subGroupResults) => new PermissionSubGroupSelectListDto
                {
                    Id = subGroupKey.Id,
                    Code = subGroupKey.Code,
                    ShortName = subGroupKey.ShortName,
                    FullName = subGroupKey.FullName,
                    Permissions = subGroupResults.Select(c => new PermissionItemSelectListDto
                    {
                        Id = c.Id,
                        Code = c.Code,
                        ShortName = c.ShortName,
                        FullName = c.FullName,
                    })
                })
            });
    }
}

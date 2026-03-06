using AutoMapper;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetRefuelBriefPageResultHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMainAuthService authService,
    ICultureHelper cultureHelper) : IRequestHandler<RefuelGetBriefPageResultQuery, WbPagedResult<RefuelBriefDto>>
{
    public async Task<WbPagedResult<RefuelBriefDto>> Handle(RefuelGetBriefPageResultQuery request, CancellationToken cancellationToken)
    {
        var query = context.Refuels.AsQueryable().MapTo<RefuelBriefDto>(mapper, cultureHelper);

        query = await query.SortFilter(request, authService);

        var result = await query.AsPagedResultAsync(request);

        result.Rows = await result.Rows.SetActionControls(authService);

        return result;
    }
}

public static class RefuelBriefDtoExtension
{
    public static async Task<IEnumerable<RefuelBriefDto>> SetActionControls(
        this IEnumerable<RefuelBriefDto> query,
        IMainAuthService authService)
    {
        foreach (var item in query)
        {
            item.CanAccept = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.ACCEPTED) &&
                             authService.HasPermission(nameof(AutoparkPermissionCode.RefuelAccept));
            item.CanCancel = false;
            item.CanSend = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.SEND) &&
                             authService.HasPermission(nameof(AutoparkPermissionCode.RefuelSend));
            item.CanDelete = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.DELETED) &&
                             authService.HasPermission(nameof(AutoparkPermissionCode.RefuelDelete));
            item.CanRevoke = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.REVOKED) &&
                             authService.HasPermission(nameof(AutoparkPermissionCode.RefuelRevoke));
            item.CanModify = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.MODIFIED) &&
                             authService.HasPermission(nameof(AutoparkPermissionCode.RefuelEdit));
        }
        return await Task.FromResult(query);
    }
}

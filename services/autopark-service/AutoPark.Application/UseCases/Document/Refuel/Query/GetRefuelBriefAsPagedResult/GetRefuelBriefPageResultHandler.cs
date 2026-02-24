using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelBriefPageResultHandler :
    IRequestHandler<GetRefuelBriefPageResultQuery, PagedResultWithActionControls<RefuelBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetRefuelBriefPageResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<RefuelBriefDto>> Handle(
        GetRefuelBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Refuel, RefuelBriefDto>(_context.Refuels);
        query = await query.SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.RefuelCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);
        return result;
    }
}

public static class RefuelBriefDtoExtension
{
    public static async Task<IEnumerable<RefuelBriefDto>> SetActionControls(this IEnumerable<RefuelBriefDto> query,
                                                                         IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var item in query)
        {
            item.CanAccept = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.ACCEPTED) &&
                             permissions.Contains(nameof(PermissionCode.RefuelAccept));
            item.CanCancel = false;
            /*item.CanCancel = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.CANCELLED) &&
							 permissions.Contains(nameof(PermissionCode.RefuelCancel));*/
            item.CanSend = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.SEND) &&
                             permissions.Contains(nameof(PermissionCode.RefuelSend));
            item.CanDelete = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.DELETED) &&
                             permissions.Contains(nameof(PermissionCode.RefuelDelete));
            item.CanRevoke = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.REVOKED) &&
                             permissions.Contains(nameof(PermissionCode.RefuelRevoke));
            item.CanModify = StatusIdConst.CanRefuelStatus(item.StatusId, StatusIdConst.MODIFIED) &&
                             permissions.Contains(nameof(PermissionCode.RefuelEdit));
        }
        return query;
    }
}

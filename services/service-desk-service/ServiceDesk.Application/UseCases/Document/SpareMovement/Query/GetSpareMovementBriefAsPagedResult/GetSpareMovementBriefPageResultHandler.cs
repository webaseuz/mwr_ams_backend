using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementBriefPageResultHandler :
    IRequestHandler<GetSpareMovementBriefPageResultQuery, PagedResultWithActionControls<SpareMovementBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetSpareMovementBriefPageResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<SpareMovementBriefDto>> Handle(
        GetSpareMovementBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<SpareMovement, SpareMovementBriefDto>(_context.SpareMovements);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.BankCreate)
        };

        await request.InitAsync(_authService);

        query = query.SortFilter(request);

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class SpareMovementBriefDtoExtension
{
    public static async Task<IEnumerable<SpareMovementBriefDto>> SetActionControls(this IEnumerable<SpareMovementBriefDto> query,
                                                                         IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var item in query)
        {
            item.CanAccept = StatusIdConst.CanSpareMovementStatus(item.StatusId, StatusIdConst.ACCEPTED) &&
                             permissions.Contains(nameof(PermissionCode.SpareMovementAccept));
            item.CanCancel = StatusIdConst.CanSpareMovementStatus(item.StatusId, StatusIdConst.CANCELLED) &&
                             permissions.Contains(nameof(PermissionCode.SpareMovementCancel));
            item.CanSend = StatusIdConst.CanSpareMovementStatus(item.StatusId, StatusIdConst.SEND) &&
                             permissions.Contains(nameof(PermissionCode.SpareMovementSend));
            item.CanDelete = StatusIdConst.CanSpareMovementStatus(item.StatusId, StatusIdConst.DELETED) &&
                             permissions.Contains(nameof(PermissionCode.SpareMovementDelete));
            item.CanRevoke = StatusIdConst.CanSpareMovementStatus(item.StatusId, StatusIdConst.REVOKED) &&
                             permissions.Contains(nameof(PermissionCode.SpareMovementRevoke));
            item.CanModify = StatusIdConst.CanSpareMovementStatus(item.StatusId, StatusIdConst.MODIFIED) &&
                             permissions.Contains(nameof(PermissionCode.SpareMovementEdit));
        }
        return query;
    }
}
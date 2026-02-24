using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationBriefPageResultHandler :
    IRequestHandler<GetServiceApplicationBriefPageResultQuery, PagedResultWithActionControls<ServiceApplicationBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetServiceApplicationBriefPageResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<ServiceApplicationBriefDto>> Handle(
        GetServiceApplicationBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<ServiceApplication, ServiceApplicationBriefDto>(_context.ServiceApplications);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.ServiceApplicationCreate)
        };

        query = await query.SortFilter(request, _authService);

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class ServiceApplicationBriefDtoExtension
{
    public static async Task<IEnumerable<ServiceApplicationBriefDto>> SetActionControls(
        this IEnumerable<ServiceApplicationBriefDto> query,
        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            var hasAccept = permissions.Contains(nameof(PermissionCode.ServiceApplicationAccept));

            ent.CanCancelByExecutor = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.CANCELED_BY_EXECUTOR) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationCancelByExecutor));
            
            ent.CanFinishByExecutor = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.FINISHED_BY_EXECUTOR) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationFinishByExecutor));
            
            ent.CanCancelByClient = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.CANCELED_BY_CLIENT) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationCancelByClient));

            ent.CanSend = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.SEND) &&
                           permissions.Contains(nameof(PermissionCode.ServiceApplicationSend));

            ent.CanRevoke = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.REVOKED) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationRevoke));

            ent.CanModify = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.MODIFIED) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationEdit));

            ent.CanDelete = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.DELETED) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationDelete));

            ent.CanInProcess = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.IN_PROCESS) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationInProcess));

            ent.CanFinish = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.FINISHED) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationFinished));

            ent.CanWaitSpares = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.WAIT_SPARES) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationWaitSpares));

            ent.CanFail = StatusIdConst.CanServiceApplicationStatus(ent.StatusId, StatusIdConst.FAILED) &&
                            permissions.Contains(nameof(PermissionCode.ServiceApplicationFail));
        }

        return query;
    }
}
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeBriefPagedResultHandler :
    IRequestHandler<GetDeviceTypeBriefPagedResultQuery, PagedResultWithActionControls<DeviceTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
    private readonly IMapProvider _mapper;

    public GetDeviceTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<DeviceTypeBriefDto>> Handle(
        GetDeviceTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<DeviceType, DeviceTypeBriefDto>(_context.DeviceTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.DistrictCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class DeviceTypeBriefDtoExtension
{
    public static async Task<IEnumerable<DeviceTypeBriefDto>> SetActionControls(this IEnumerable<DeviceTypeBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.DeviceTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.DeviceTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.DeviceTypeDelete));
        }

        return query;
    }
}

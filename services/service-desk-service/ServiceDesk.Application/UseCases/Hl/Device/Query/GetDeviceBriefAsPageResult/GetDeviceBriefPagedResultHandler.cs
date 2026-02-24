using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceBriefPagedResultHandler :
    IRequestHandler<GetDeviceBriefPagedResultQuery, PagedResultWithActionControls<DeviceBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetDeviceBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _mapper = mapper;
        _appAuthService = appAuthService;
    }

    public async Task<PagedResultWithActionControls<DeviceBriefDto>> Handle(
        GetDeviceBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        await request.Init(_appAuthService);

        var query = _mapper.MapCollection<Device, DeviceBriefDto>(_context.Devices.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _appAuthService.HasPermissionAsync(PermissionCode.DeviceCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}

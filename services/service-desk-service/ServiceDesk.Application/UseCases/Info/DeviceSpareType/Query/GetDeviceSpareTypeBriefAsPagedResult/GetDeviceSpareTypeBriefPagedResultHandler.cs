using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;
using Bms.Core.Application.Models;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeBriefPagedResultHandler :
    IRequestHandler<GetDeviceSpareTypeBriefPagedResultQuery, PagedResultWithActionControls<DeviceSpareTypeBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetDeviceSpareTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<DeviceSpareTypeBriefDto>> Handle(
		GetDeviceSpareTypeBriefPagedResultQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<DeviceSpareType, DeviceSpareTypeBriefDto>(_context.DeviceSpareTypes.IsSoftActive());

        query = query.SortFilter(request);

		var actionControls = new PagedResultActionControl
		{
			CanCreate = await _authService.HasPermissionAsync(PermissionCode.BankCreate)
		};
		var result = await query.AsPagedResultWithActionControlAsync(request,
																	 actionControls,
																	 cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);
        
        return result;
    }
}
public static class DeviceSpareTypeBriefDtoExtension
{
	public static async Task<IEnumerable<DeviceSpareTypeBriefDto>> SetActionControls(this IEnumerable<DeviceSpareTypeBriefDto> query,

		IAsyncAppAuthService authService)
	{
		var permissions = await authService.GetPermissionsAsync();

		foreach (var ent in query)
		{
			ent.CanView = permissions.Contains(nameof(PermissionCode.DeviceSpareTypeView));
			ent.CanModify = permissions.Contains(nameof(PermissionCode.DeviceSpareTypeEdit));
			ent.CanDelete = permissions.Contains(nameof(PermissionCode.DeviceSpareTypeDelete));
		}

		return query;
	}
}
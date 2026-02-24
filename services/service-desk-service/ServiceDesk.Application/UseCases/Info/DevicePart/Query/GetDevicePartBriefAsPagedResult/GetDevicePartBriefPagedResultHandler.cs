using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.DeviceTypes;
using Bms.Core.Application.Models;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartBriefPagedResultHandler :
    IRequestHandler<GetDevicePartBriefPagedResultQuery, PagedResultWithActionControls<DevicePartBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetDevicePartBriefPagedResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<DevicePartBriefDto>> Handle(
		GetDevicePartBriefPagedResultQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<DevicePart, DevicePartBriefDto>(_context.DeviceParts.IsSoftActive());

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
public static class DevicePartBriefDtoExtension
{
	public static async Task<IEnumerable<DevicePartBriefDto>> SetActionControls(this IEnumerable<DevicePartBriefDto> query,

		IAsyncAppAuthService authService)
	{
		var permissions = await authService.GetPermissionsAsync();

		foreach (var ent in query)
		{
			ent.CanView = permissions.Contains(nameof(PermissionCode.DevicePartView));
			ent.CanModify = permissions.Contains(nameof(PermissionCode.DevicePartEdit));
			ent.CanDelete = permissions.Contains(nameof(PermissionCode.DevicePartDelete));
		}

		return query;
	}
}
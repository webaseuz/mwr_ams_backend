using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.DeviceTypes;
using Bms.Core.Application.Models;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelBriefPagedResultHandler :
    IRequestHandler<GetDeviceModelBriefPagedResultQuery, PagedResultWithActionControls<DeviceModelBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetDeviceModelBriefPagedResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<DeviceModelBriefDto>> Handle(
		GetDeviceModelBriefPagedResultQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<DeviceModel, DeviceModelBriefDto>(_context.DeviceModels.IsSoftActive());

        query = query.SortFilter(request);

		var actionControls = new PagedResultActionControl
		{
			CanCreate = await _authService.HasPermissionAsync(PermissionCode.DeviceModelCreate)
		};
		var result = await query.AsPagedResultWithActionControlAsync(request,
																	 actionControls,
																	 cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}
public static class DeviceModelBriefDtoExtension
{
	public static async Task<IEnumerable<DeviceModelBriefDto>> SetActionControls(this IEnumerable<DeviceModelBriefDto> query,

		IAsyncAppAuthService authService)
	{
		var permissions = await authService.GetPermissionsAsync();

		foreach (var ent in query)
		{
			ent.CanView = permissions.Contains(nameof(PermissionCode.DeviceModelView));
			ent.CanModify = permissions.Contains(nameof(PermissionCode.DeviceModelEdit));
			ent.CanDelete = permissions.Contains(nameof(PermissionCode.DeviceModelDelete));
		}

		return query;
	}
}
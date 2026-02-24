using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class GetBatteryTypeBriefPagedResultHandler :
     IRequestHandler<GetBatteryTypeBriefPagedResultQuery, PagedResultWithActionControls<BatteryTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetBatteryTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<BatteryTypeBriefDto>> Handle(
        GetBatteryTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<BatteryType, BatteryTypeBriefDto>(_context.BatteryTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.BatteryTypeCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
        result.Rows = await result.Rows.SetActionControls(_authService);
        return result;
    }
}

public static class BatteryTypeBriefDtoExtension
{
    public static async Task<IEnumerable<BatteryTypeBriefDto>> SetActionControls(this IEnumerable<BatteryTypeBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.BatteryTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.BatteryTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.BatteryTypeDelete));
        }

        return query;
    }
}
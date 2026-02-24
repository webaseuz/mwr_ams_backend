using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportSettings;

public class GetTransportSettingBriefAsPageResultHandler :
    IRequestHandler<GetTransportSettingBriefAsPageResultQuery, PagedResultWithActionControls<TransportSettingBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetTransportSettingBriefAsPageResultHandler(IReadEfCoreContext context,
                                                       IMapProvider mapper,
                                                       IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }
    public async Task<PagedResultWithActionControls<TransportSettingBriefDto>> Handle(GetTransportSettingBriefAsPageResultQuery request,
                                                                    CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TransportSetting, TransportSettingBriefDto>(_context.TransportSettings);

        query = await query.SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportSettingCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);


        var transportIds = result.Rows.Select(x => x.TransportId).ToList();

        var fuelCardNumbers = await _context.FuelCards
            .Where(x => transportIds.Contains((int)x.TransportId))
            .ToListAsync(cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService, fuelCardNumbers);


        return result;
    }

}

public static class TransportSettingBriefDtoExtension
{
    public static async Task<IEnumerable<TransportSettingBriefDto>> SetActionControls(this IEnumerable<TransportSettingBriefDto> query,
                                                                         IAsyncAppAuthService authService, List<FuelCard> fuelCards)
    {
        var permissions = await authService.GetPermissionsAsync();


        foreach (var ent in query)
        {
            ent.CanAccept = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.ACCEPTED) &&
                           permissions.Contains(nameof(PermissionCode.TransportSettingAccept));

            ent.CanDelete = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.DELETED) &&
                          permissions.Contains(nameof(PermissionCode.TransportSettingDelete));

            ent.CanModify = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.MODIFIED) &&
                         permissions.Contains(nameof(PermissionCode.TransportSettingEdit));

            ent.CanCancel = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.CANCELLED) &&
                            permissions.Contains(nameof(PermissionCode.TransportSettingCancel));

            ent.FuelCardNumber = fuelCards.FirstOrDefault(x => x.TransportId == ent.TransportId)?.CardNumber ?? string.Empty;
        }

        return query;
    }
}
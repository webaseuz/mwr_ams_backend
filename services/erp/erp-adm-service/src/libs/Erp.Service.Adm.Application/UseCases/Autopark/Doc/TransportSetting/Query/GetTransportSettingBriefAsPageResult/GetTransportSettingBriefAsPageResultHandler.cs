using AutoMapper;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportSettingBriefAsPageResultHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMainAuthService authService,
    ICultureHelper cultureHelper) : IRequestHandler<TransportSettingGetBriefPageResultQuery, WbPagedResult<TransportSettingBriefDto>>
{
    public async Task<WbPagedResult<TransportSettingBriefDto>> Handle(
        TransportSettingGetBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.TransportSettings.AsQueryable().MapTo<TransportSettingBriefDto>(mapper, cultureHelper);

        query = await query.SortFilter(request, authService);

        var result = await query.AsPagedResultAsync(request);

        var transportIds = result.Rows.Select(x => x.TransportId).ToList();
        var fuelCards = await context.FuelCards
            .Where(x => transportIds.Contains((int)x.TransportId))
            .ToListAsync(cancellationToken);

        result.Rows = result.Rows.SetActionControls(authService, fuelCards);

        return result;
    }
}

public static class TransportSettingBriefDtoExtension
{
    public static IEnumerable<TransportSettingBriefDto> SetActionControls(
        this IEnumerable<TransportSettingBriefDto> query,
        IMainAuthService authService,
        List<FuelCard> fuelCards)
    {
        foreach (var ent in query)
        {
            ent.CanAccept = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.ACCEPTED) &&
                            authService.HasPermission(nameof(AdmPermissionCode.TransportSettingAccept));

            ent.CanDelete = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.DELETED) &&
                            authService.HasPermission(nameof(AdmPermissionCode.TransportSettingDelete));

            ent.CanModify = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.MODIFIED) &&
                            authService.HasPermission(nameof(AdmPermissionCode.TransportSettingEdit));

            ent.CanCancel = StatusIdConst.CanTransportSettingStatus(ent.StatusId, StatusIdConst.CANCELLED) &&
                            authService.HasPermission(nameof(AdmPermissionCode.TransportSettingCancel));

            ent.FuelCardNumber = fuelCards.FirstOrDefault(x => x.TransportId == ent.TransportId)?.CardNumber ?? string.Empty;
        }

        return query;
    }
}

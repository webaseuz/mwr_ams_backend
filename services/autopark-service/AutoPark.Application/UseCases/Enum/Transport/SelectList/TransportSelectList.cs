using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Transports;

public static class TransportSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Transport> query,
                                                           GetTransportSelectListQuery request,
                                                           IAsyncAppAuthService appAuthService,
                                                           CancellationToken cancellationToken)
    {
        var user = await appAuthService.GetUserAsync();

        if (!user.Permissions.Contains(nameof(PermissionCode.AllViewTransport)))
            request.BranchId = user.BranchId;

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (!user.Permissions.Contains(nameof(PermissionCode.TransportBranchView)))
        {
            request.DriverId = null;
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED) &&
                                     q.Settings.FirstOrDefault(s => s.StatusId == StatusIdConst.ACCEPTED).Driver.PersonId == user.PersonId);
        }

        if (request.DriverId.HasValue)
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED) &&
                                     q.Settings.FirstOrDefault(s => s.StatusId == StatusIdConst.ACCEPTED).DriverId == request.DriverId);

        if (request.FromSetting.HasValue && request.FromSetting == true)
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED));

        if (request.FromSetting.HasValue && request.FromSetting == false)
            query = query.Where(q => q.Settings.Count == 0 || q.Settings.All(a => a.StatusId != StatusIdConst.ACCEPTED));

        var result = await query
            .IsSoftActive()
            .Where(q => q.TransportModel.StateId == StateIdConst.ACTIVE)
            .Select(a =>
            new TransportSelectListItem<int>
            {
                Value = a.Id,
                OrderCode = a.OrderCode,
                Text = a.StateCode + " " + a.StateNumber + " (" + (a.TransportModel.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? a.TransportModel.FullName) + ")",
                TransportModelId = a.TransportModelId,
                SettingId = a.Settings.Count > 0 ? a.Settings.Where(a => a.StatusId == StatusIdConst.ACCEPTED).OrderByDescending(a => a.Id).FirstOrDefault().Id : null,

            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

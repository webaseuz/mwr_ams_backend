using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Drivers;

public static class DriverSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Driver> query,
                                                           GetDriverSelectListQuery request,
                                                           IAsyncAppAuthService appAuthService,
                                                           CancellationToken cancellationToken)
    {
        var user = await appAuthService.GetUserAsync();

        if (!await appAuthService.HasPermissionAsync(nameof(PermissionCode.AllViewDriver)))
            request.BranchId = user.BranchId;

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.TransportSettingId.HasValue)
            query = query.Where(q => q.Settings.Any(a => a.Id == request.TransportSettingId));

        if (!user.Permissions.Contains(nameof(PermissionCode.DriverBranchView)))
            query = query.Where(q => q.PersonId == user.PersonId);

        if (request.TransportId.HasValue)
            query = query.Where(q => q.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED) &&
                                     q.Settings.FirstOrDefault(s => s.StatusId == StatusIdConst.ACCEPTED).TransportId == request.TransportId);

        var result = await query
            .IsSoftActive()
            .Select(a =>
            new DriverSelectListItem<int>
            {
                Value = a.Id,
                Text = a.Person.Pinfl + " - " + a.Person.FullName
            })
            .AsQueryable()
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

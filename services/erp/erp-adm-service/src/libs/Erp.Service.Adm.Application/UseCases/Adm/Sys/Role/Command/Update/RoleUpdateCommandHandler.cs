using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain.Entities.Sys;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RoleUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RoleUpdateCommand, bool>
{
    public async Task<bool> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Roles
            .Include(x => x.RolePermissions)
            .Include(x => x.Translates)
            .Where(x => !x.IsDeleted)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "ROLE_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("ROLE_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.OrderCode = request.OrderCode;
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.IsAdmin = request.IsAdmin;
        entity.StateId = request.StateId;

        // Update permissions
        var newPermIds = request.Permissions.ToHashSet();
        foreach (var rp in entity.RolePermissions.Where(x => !x.IsDeleted).ToList())
        {
            if (!newPermIds.Contains(rp.PermissionId))
                rp.IsDeleted = true;
        }
        var existingPermIds = entity.RolePermissions.Where(x => !x.IsDeleted).Select(x => x.PermissionId).ToHashSet();
        foreach (var p in request.Permissions.Where(p => !existingPermIds.Contains(p)))
            entity.RolePermissions.Add(new RolePermission { PermissionId = p });

        // Update translates
        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates);

        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

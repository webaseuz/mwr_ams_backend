using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Core.Service.Domain.Entities.Sys;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RoleCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<RoleCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Role
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            IsAdmin = request.IsAdmin,
            StateId = WbStateIdConst.ACTIVE,
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new RoleTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName,
                TranslateText = t.TranslateText,
            });

        foreach (var p in request.Permissions)
            entity.RolePermissions.Add(new RolePermission { PermissionId = p });

        context.Roles.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

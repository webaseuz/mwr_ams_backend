using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UpdateNotificationTemplateSettingCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<UpdateNotificationTemplateSettingCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(UpdateNotificationTemplateSettingCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.NotificationTemplateSettings
            .Include(x => x.Users.Where(u => !u.IsDeleted))
            .Include(x => x.Roles.Where(r => !r.IsDeleted))
            .Include(x => x.RestrictedUsers.Where(ru => !ru.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.CanNotificationTemplateSettingStatus(entity.StatusId, StatusIdConst.MODIFIED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_EDITING",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_EDITING").ToString()
                });

        entity.StatusId = StatusIdConst.MODIFIED;
        entity.DocDate = request.DocDate;
        entity.NotificationTemplateId = request.NotificationTemplateId;
        entity.BranchId = request.BranchId;

        // Users
        {
            var reqIds = request.Users.Select(u => u.Id).ToHashSet();
            foreach (var row in entity.Users.Where(u => !reqIds.Contains(u.Id)).ToList())
                row.IsDeleted = true;
            foreach (var u in request.Users.Where(u => u.Id > 0))
            {
                var row = entity.Users.FirstOrDefault(x => x.Id == u.Id);
                if (row is null) continue;
                row.UserId = u.UserId;
            }
            foreach (var u in request.Users.Where(u => u.Id == 0))
                entity.Users.Add(new NotificationTemplateSettingUser { UserId = u.UserId });
        }

        // Roles
        {
            var reqIds = request.Roles.Select(r => r.Id).ToHashSet();
            foreach (var row in entity.Roles.Where(r => !reqIds.Contains(r.Id)).ToList())
                row.IsDeleted = true;
            foreach (var r in request.Roles.Where(r => r.Id > 0))
            {
                var row = entity.Roles.FirstOrDefault(x => x.Id == r.Id);
                if (row is null) continue;
                row.RoleId = r.RoleId;
            }
            foreach (var r in request.Roles.Where(r => r.Id == 0))
                entity.Roles.Add(new NotificationTemplateSettingRole { RoleId = r.RoleId });
        }

        // RestrictedUsers
        {
            var reqIds = request.RestrictedUsers.Select(ru => ru.Id).ToHashSet();
            foreach (var row in entity.RestrictedUsers.Where(ru => !reqIds.Contains(ru.Id)).ToList())
                row.IsDeleted = true;
            foreach (var ru in request.RestrictedUsers.Where(ru => ru.Id > 0))
            {
                var row = entity.RestrictedUsers.FirstOrDefault(x => x.Id == ru.Id);
                if (row is null) continue;
                row.UserId = ru.UserId;
            }
            foreach (var ru in request.RestrictedUsers.Where(ru => ru.Id == 0))
                entity.RestrictedUsers.Add(new NotificationTemplateSettingRestrictedUser { UserId = ru.UserId });
        }

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return new WbHaveId<long>(request.Id);
    }
}

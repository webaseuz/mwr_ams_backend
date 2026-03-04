using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateNotificationTemplateSettingCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<CreateNotificationTemplateSettingCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(CreateNotificationTemplateSettingCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = new NotificationTemplateSetting
            {
                DocDate = request.DocDate,
                NotificationTemplateId = request.NotificationTemplateId,
                BranchId = request.BranchId,
                StatusId = StatusIdConst.CREATED
            };

            var userInfo = authService.User;
            if (!userInfo.Permissions.Contains(nameof(PermissionCode.NotificationTemplateSettingCreateForAllBranch)))
                entity.BranchId = userInfo.BranchId;

            var haveSameIds = request.Users.Select(x => x.UserId).Intersect(request.RestrictedUsers.Select(x => x.UserId)).Any();
            if (request.Users.Any() && request.RestrictedUsers.Any() && haveSameIds)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "USERS_AND_RESTRICTED_USERS_CONFLICT",
                        ErrorMessage = localizationBuilder.For("USERS_AND_RESTRICTED_USERS_CONFLICT").ToString()
                    });

            foreach (var u in request.Users)
                entity.Users.Add(new NotificationTemplateSettingUser { UserId = u.UserId });

            foreach (var r in request.Roles)
                entity.Roles.Add(new NotificationTemplateSettingRole { RoleId = r.RoleId });

            foreach (var ru in request.RestrictedUsers)
                entity.RestrictedUsers.Add(new NotificationTemplateSettingRestrictedUser { UserId = ru.UserId });

            await context.NotificationTemplateSettings.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return new WbHaveId<long>(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

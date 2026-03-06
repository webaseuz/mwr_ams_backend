using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CancelNotificationTemplateSettingCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<CancelNotificationTemplateSettingCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(CancelNotificationTemplateSettingCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var document = await context.NotificationTemplateSettings
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (document is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.CanNotificationTemplateSettingStatus(document.StatusId, StatusIdConst.CANCELLED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_CANCELLATION",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_CANCELLATION").ToString()
                });

        document.StatusId = StatusIdConst.CANCELLED;

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return new WbHaveId<long>(request.Id);
    }
}

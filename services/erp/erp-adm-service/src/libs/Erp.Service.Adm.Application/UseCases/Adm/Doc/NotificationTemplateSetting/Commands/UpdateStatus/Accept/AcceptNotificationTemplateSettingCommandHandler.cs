using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class AcceptNotificationTemplateSettingCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<AcceptNotificationTemplateSettingCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(AcceptNotificationTemplateSettingCommand request, CancellationToken cancellationToken)
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

        if (!StatusIdConst.CanNotificationTemplateSettingStatus(document.StatusId, StatusIdConst.ACCEPTED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_APPROVAL",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_APPROVAL").ToString()
                });

        var hasAcceptedDocument = await context.NotificationTemplateSettings
            .AnyAsync(x => x.BranchId == document.BranchId
                        && x.StatusId == StatusIdConst.ACCEPTED
                        && x.NotificationTemplateId == document.NotificationTemplateId, cancellationToken);

        if (hasAcceptedDocument)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "ACCEPTED_DOCUMENT_ALREADY_EXISTS",
                    ErrorMessage = localizationBuilder.For("ACCEPTED_DOCUMENT_ALREADY_EXISTS").ToString()
                });

        document.StatusId = StatusIdConst.ACCEPTED;

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return new WbHaveId<long>(request.Id);
    }
}

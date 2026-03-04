using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class AcceptTransportSettingHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<TransportSettingAcceptCommand, bool>
{
    public async Task<bool> Handle(TransportSettingAcceptCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.TransportSettings
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.CanTransportSettingStatus(entity.StatusId, StatusIdConst.ACCEPTED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_APPROVAL",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_APPROVAL").ToString()
                });

        var existAccepted = await context.TransportSettings
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.TransportId == entity.TransportId
                && d.StatusId == StatusIdConst.ACCEPTED
                && d.Id != entity.Id, cancellationToken);

        if (existAccepted is not null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "TRANSPORT_SETTING_ALREADY_ACCEPTED",
                    ErrorMessage = localizationBuilder.For("TRANSPORT_SETTING_ALREADY_ACCEPTED")
                        .WithData(new { DocNumber = existAccepted.DocNumber }).ToString()
                });

        entity.StatusId = StatusIdConst.ACCEPTED;

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return true;
    }
}

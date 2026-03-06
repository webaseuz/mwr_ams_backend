using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class AcceptRefuelCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RefuelAcceptCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(RefuelAcceptCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.Refuels
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.CanRefuelStatus(entity.StatusId, StatusIdConst.ACCEPTED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_APPROVAL",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_APPROVAL").ToString()
                });

        entity.StatusId = StatusIdConst.ACCEPTED;

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return new WbHaveId<long>(request.Id);
    }
}

using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UpdateFuelCardCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<FuelCardUpdateCommand, bool>
{
    public async Task<bool> Handle(FuelCardUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.FuelCards
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "FUEL_CARD_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("FUEL_CARD_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        var expireAt = DateTime.ParseExact(request.ExpireAt, "MM/yy", CultureInfo.InvariantCulture);

        if (expireAt < DateTime.UtcNow.Date)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "FUEL_CARD_EXPIRED",
                    ErrorMessage = localizationBuilder.For("FUEL_CARD_EXPIRED").ToString()
                });

        entity.DriverId = request.DriverId;
        entity.BranchId = request.BranchId;
        entity.TransportId = request.TransportId;
        entity.PlasticCardTypeId = request.PlasticCardTypeId;
        entity.CardNumber = request.CardNumber;
        entity.ExpireAt = expireAt;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

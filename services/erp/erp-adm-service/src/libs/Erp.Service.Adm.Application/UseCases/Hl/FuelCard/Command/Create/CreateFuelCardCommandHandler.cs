using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using System.Globalization;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateFuelCardCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<FuelCardCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(FuelCardCreateCommand request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;
        if (!userInfo.Permissions.Contains(nameof(PermissionCode.FuelCardCreate)))
            request.BranchId = userInfo.BranchId;

        var expireAt = DateTime.ParseExact(request.ExpireAt, "MM/yy", CultureInfo.InvariantCulture);

        if (expireAt < DateTime.UtcNow.Date)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "FUEL_CARD_EXPIRED",
                    ErrorMessage = localizationBuilder.For("FUEL_CARD_EXPIRED").ToString()
                });

        var entity = new FuelCard
        {
            DriverId = request.DriverId,
            BranchId = request.BranchId,
            TransportId = request.TransportId,
            PlasticCardTypeId = request.PlasticCardTypeId,
            CardNumber = request.CardNumber,
            ExpireAt = expireAt,
            StateId = WbStateIdConst.ACTIVE
        };

        await context.FuelCards.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

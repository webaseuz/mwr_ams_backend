using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateRefuelCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RefuelCreateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(RefuelCreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var hasInfo = await context.FuelCards
                .AnyAsync(fc => !fc.IsDeleted &&
                                fc.Id == request.FuelCardId &&
                                fc.TransportId == request.TransportId, cancellationToken);

            if (!hasInfo)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "INVALID_FUEL_CARD",
                        ErrorMessage = localizationBuilder.For("INVALID_FUEL_CARD").WithData(new { TransportId = request.TransportId }).ToString()
                    });

            var entity = new Refuel
            {
                DocDate = request.DocDate,
                BranchId = request.BranchId,
                FuelCardId = request.FuelCardId,
                TransportId = request.TransportId,
                DriverId = request.DriverId,
                FuelTypeId = request.FuelTypeId,
                Litre = request.Litre,
                LitrePrice = request.LitrePrice,
                ChequeNumber = request.ChequeNumber,
                Address = request.Address,
                Message = request.Message,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                StatusId = StatusIdConst.CREATED
            };

            var userInfo = authService.User;
            if (!userInfo.Permissions.Contains(nameof(PermissionCode.RefuelCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            if (!request.Latitude.HasValue || !request.Longitude.HasValue)
            {
                var presentTrackInfo = await context.PresentTrackingInfos
                    .FirstOrDefaultAsync(pt => pt.Person.Drivers.Any(d => d.Id == request.DriverId), cancellationToken);

                if (presentTrackInfo != null)
                {
                    entity.Latitude = presentTrackInfo.Latitude;
                    entity.Longitude = presentTrackInfo.Longitude;
                }
            }

            if (request.Files.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                    FileStorageConst.REFUEL_FILE,
                    request.Files.Select(x => x.Id).ToArray());
                foreach (var fi in fileInfos)
                    entity.Files.Add(new RefuelFile { Id = fi.FileId, FileName = fi.FileName });
            }

            await context.Refuels.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            if (request.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.REFUEL_FILE,
                    entity.Id.ToString(),
                    request.Files.Select(x => x.Id).ToArray());

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

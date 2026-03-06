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

internal sealed class UpdateRefuelCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RefuelUpdateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(RefuelUpdateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await context.Refuels
                .Include(x => x.Files.Where(f => !f.IsDeleted))
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "DOCUMENT_NOT_FOUND",
                        ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                    });

            if (!StatusIdConst.CanRefuelStatus(entity.StatusId, StatusIdConst.MODIFIED))
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "STATUS_NOT_ALLOWED_FOR_EDITING",
                        ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_EDITING").ToString()
                    });

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

            entity.StatusId = StatusIdConst.MODIFIED;
            entity.DocDate = request.DocDate;
            entity.FuelCardId = request.FuelCardId;
            entity.TransportId = request.TransportId;
            entity.DriverId = request.DriverId;
            entity.BranchId = request.BranchId;
            entity.FuelTypeId = request.FuelTypeId;
            entity.Litre = request.Litre;
            entity.LitrePrice = request.LitrePrice;
            entity.ChequeNumber = request.ChequeNumber;
            entity.Address = request.Address;
            entity.Message = request.Message;
            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;

            var userInfo = authService.User;
            if (!userInfo.Permissions.Contains(nameof(AutoparkPermissionCode.RefuelCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            var requestIds = request.Files.Select(f => f.Id).ToHashSet();
            foreach (var f in entity.Files.Where(f => !requestIds.Contains(f.Id)).ToList())
                f.IsDeleted = true;

            var existingIds = entity.Files.Select(f => f.Id).ToHashSet();
            var newIds = request.Files.Where(f => !existingIds.Contains(f.Id)).Select(f => f.Id).ToArray();
            if (newIds.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.REFUEL_FILE, newIds);
                foreach (var fi in fileInfos)
                {
                    entity.Files.Add(new RefuelFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.REFUEL_FILE, entity.Id.ToString(), fi.FileId);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.REFUEL_FILE, entity.Id.ToString());

            await transaction.CommitAsync(cancellationToken);
            return new WbHaveId<long>(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

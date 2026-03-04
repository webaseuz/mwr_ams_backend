using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UpdateTransportCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder,
    IWbStorageService wbStorageService) : IRequestHandler<TransportUpdateCommand, bool>
{
    public async Task<bool> Handle(TransportUpdateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await context.Transports
                .Include(x => x.Files.Where(f => !f.IsDeleted))
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken);

            if (entity is null)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "DOCUMENT_NOT_FOUND",
                        ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                    });

            entity.OrderCode = request.OrderCode;
            entity.BranchId = request.BranchId;
            entity.DepartmentId = request.DepartmentId;
            entity.TransportModelId = request.TransportModelId;
            entity.TransportUseTypeId = request.TransportUseTypeId;
            entity.TransportBrandId = request.TransportBrandId;
            entity.TransportColorId = request.TransportColorId;
            entity.ManufacturedAt = request.ManufacturedAt;
            entity.PurchasedAt = request.PurchasedAt;
            entity.StateCode = request.StateCode;
            entity.StateNumber = request.StateNumber;
            entity.VinNumber = request.VinNumber;
            entity.PurchasedAmount = request.PurchasedAmount;
            entity.AmortizationPeriod = request.AmortizationPeriod;

            var requestIds = request.Files.Select(f => f.Id).ToHashSet();
            foreach (var f in entity.Files.Where(f => !requestIds.Contains(f.Id)).ToList())
                f.IsDeleted = true;

            var existingIds = entity.Files.Select(f => f.Id).ToHashSet();
            var newIds = request.Files.Where(f => !existingIds.Contains(f.Id)).Select(f => f.Id).ToArray();
            if (newIds.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.TRANSPORT_FILE, newIds);
                foreach (var fi in fileInfos)
                {
                    entity.Files.Add(new TransportFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.TRANSPORT_FILE, entity.Id.ToString(), fi.FileId);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.TRANSPORT_FILE, entity.Id.ToString());
            await transaction.CommitAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

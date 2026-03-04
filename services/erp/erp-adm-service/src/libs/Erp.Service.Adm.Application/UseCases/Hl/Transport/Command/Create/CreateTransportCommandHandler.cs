using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateTransportCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<TransportCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(TransportCreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = new Transport
            {
                OrderCode = request.OrderCode,
                BranchId = request.BranchId,
                DepartmentId = request.DepartmentId,
                TransportModelId = request.TransportModelId,
                TransportUseTypeId = request.TransportUseTypeId,
                TransportBrandId = request.TransportBrandId,
                TransportColorId = request.TransportColorId,
                ManufacturedAt = request.ManufacturedAt,
                PurchasedAt = request.PurchasedAt,
                StateCode = request.StateCode,
                StateNumber = request.StateNumber,
                VinNumber = request.VinNumber,
                PurchasedAmount = request.PurchasedAmount,
                AmortizationPeriod = request.AmortizationPeriod,
                UniqueCode = Guid.NewGuid(),
                StateId = WbStateIdConst.ACTIVE
            };

            if (request.Files.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                    FileStorageConst.TRANSPORT_FILE,
                    request.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                    entity.Files.Add(new TransportFile { Id = fi.FileId, FileName = fi.FileName });
            }

            await context.Transports.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            if (request.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.TRANSPORT_FILE,
                    entity.Id.ToString(),
                    request.Files.Select(f => f.Id).ToArray());

            await transaction.CommitAsync(cancellationToken);
            return new WbHaveId<int>(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

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

internal sealed class TransportModelUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder,
    IWbStorageService wbStorageService) : IRequestHandler<TransportModelUpdateCommand, bool>
{
    public async Task<bool> Handle(TransportModelUpdateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.TransportModels
            .Include(x => x.Translates)
            .Include(x => x.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Fuels.Where(f => !f.IsDeleted))
            .Include(x => x.Liquids.Where(l => !l.IsDeleted))
            .Include(x => x.Oils.Where(o => !o.IsDeleted))
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
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.TransportTypeId = request.TransportTypeId;
        entity.TransportBrandId = request.TransportBrandId;
        entity.TransmissionBoxTypeId = request.TransmissionBoxTypeId;
        entity.LoadCapacity = request.LoadCapacity;
        entity.SeatCount = request.SeatCount;
        entity.ConsumptionPer100Km = request.ConsumptionPer100Km;
        entity.ConsumptionPerHour = request.ConsumptionPerHour;

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates);

        // Files
        {
            var requestIds = request.Files.Select(f => f.Id).ToHashSet();
            foreach (var f in entity.Files.Where(f => !requestIds.Contains(f.Id)).ToList())
                f.IsDeleted = true;
            var existingIds = entity.Files.Select(f => f.Id).ToHashSet();
            var newIds = request.Files.Where(f => !existingIds.Contains(f.Id)).Select(f => f.Id).ToArray();
            if (newIds.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.TRANSPORT_MODEL_FILE, newIds);
                foreach (var fi in fileInfos)
                {
                    var original = request.Files.FirstOrDefault(f => f.Id == fi.FileId);
                    entity.Files.Add(new TransportModelFile
                    {
                        Id = fi.FileId,
                        FileName = fi.FileName,
                        TransportColorId = original!.TransportColorId
                    });
                    await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.TRANSPORT_MODEL_FILE, entity.Id.ToString(), fi.FileId);
                }
            }
        }

        // Fuels
        {
            var reqIds = request.Fuels.Select(f => f.Id).ToHashSet();
            foreach (var row in entity.Fuels.Where(f => !reqIds.Contains(f.Id)).ToList())
                row.IsDeleted = true;
            foreach (var f in request.Fuels.Where(f => f.Id > 0))
            {
                var row = entity.Fuels.FirstOrDefault(x => x.Id == f.Id);
                if (row is null) continue;
                row.FuelTypeId = f.FuelTypeId;
                row.TankVolume = f.TankVolume;
            }
            foreach (var f in request.Fuels.Where(f => f.Id == 0))
                entity.Fuels.Add(new TransportModelFuel
                {
                    FuelTypeId = f.FuelTypeId,
                    TankVolume = f.TankVolume
                });
        }

        // Liquids
        {
            var reqIds = request.Liquids.Select(l => l.Id).ToHashSet();
            foreach (var row in entity.Liquids.Where(l => !reqIds.Contains(l.Id)).ToList())
                row.IsDeleted = true;
            foreach (var l in request.Liquids.Where(l => l.Id > 0))
            {
                var row = entity.Liquids.FirstOrDefault(x => x.Id == l.Id);
                if (row is null) continue;
                row.LiquidTypeId = l.LiquidTypeId;
                row.TankVolume = l.TankVolume;
            }
            foreach (var l in request.Liquids.Where(l => l.Id == 0))
                entity.Liquids.Add(new TransportModelLiquid
                {
                    LiquidTypeId = l.LiquidTypeId,
                    TankVolume = l.TankVolume
                });
        }

        // Oils
        {
            var reqIds = request.Oils.Select(o => o.Id).ToHashSet();
            foreach (var row in entity.Oils.Where(o => !reqIds.Contains(o.Id)).ToList())
                row.IsDeleted = true;
            foreach (var o in request.Oils.Where(o => o.Id > 0))
            {
                var row = entity.Oils.FirstOrDefault(x => x.Id == o.Id);
                if (row is null) continue;
                row.OilTypeId = o.OilTypeId;
                row.OilModelId = o.OilModelId;
                row.TankVolume = o.TankVolume;
            }
            foreach (var o in request.Oils.Where(o => o.Id == 0))
                entity.Oils.Add(new TransportModelOil
                {
                    OilTypeId = o.OilTypeId,
                    OilModelId = o.OilModelId,
                    TankVolume = o.TankVolume
                });
        }

        await context.SaveChangesAsync(cancellationToken);
        await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.TRANSPORT_MODEL_FILE, entity.Id.ToString());
        await transaction.CommitAsync(cancellationToken);
        return true;
    }
}

using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportModelCreateCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<TransportModelCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(TransportModelCreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = new TransportModel
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            TransportTypeId = request.TransportTypeId,
            TransportBrandId = request.TransportBrandId,
            TransmissionBoxTypeId = request.TransmissionBoxTypeId,
            LoadCapacity = request.LoadCapacity,
            SeatCount = request.SeatCount,
            ConsumptionPer100Km = request.ConsumptionPer100Km,
            ConsumptionPerHour = request.ConsumptionPerHour,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new TransportModelTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        foreach (var f in request.Fuels)
            entity.Fuels.Add(new TransportModelFuel
            {
                FuelTypeId = f.FuelTypeId,
                TankVolume = f.TankVolume
            });

        foreach (var l in request.Liquids)
            entity.Liquids.Add(new TransportModelLiquid
            {
                LiquidTypeId = l.LiquidTypeId,
                TankVolume = l.TankVolume
            });

        foreach (var o in request.Oils)
            entity.Oils.Add(new TransportModelOil
            {
                OilTypeId = o.OilTypeId,
                OilModelId = o.OilModelId,
                TankVolume = o.TankVolume
            });

        await context.TransportModels.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        if (request.Files.Any())
        {
            var fileIds = request.Files.Select(f => f.Id).ToArray();
            var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.TRANSPORT_MODEL_FILE, fileIds);
            foreach (var fi in fileInfos)
            {
                var original = request.Files.FirstOrDefault(f => f.Id == fi.FileId);
                entity.Files.Add(new TransportModelFile
                {
                    Id = fi.FileId,
                    FileName = fi.FileName,
                    TransportColorId = original!.TransportColorId
                });
            }
            await context.SaveChangesAsync(cancellationToken);
            await wbStorageService.MoveToPersistentAsync(FileStorageConst.TRANSPORT_MODEL_FILE, entity.Id.ToString(), fileIds);
        }

        await transaction.CommitAsync(cancellationToken);
        return new WbHaveId<int>(entity.Id);
    }
}

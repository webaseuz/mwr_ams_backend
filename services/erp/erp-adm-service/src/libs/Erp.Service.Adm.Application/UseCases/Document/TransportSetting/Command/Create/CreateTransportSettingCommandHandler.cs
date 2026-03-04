using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateTransportSettingCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    IWbStorageService wbStorageService) : IRequestHandler<TransportSettingCreateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(TransportSettingCreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var userInfo = authService.User;

        var entity = new TransportSetting
        {
            TransportId = request.TransportId,
            DriverId = request.DriverId,
            BranchId = request.BranchId ?? userInfo.BranchId ?? 0,
            ManagerId = request.ManagerId,
            LicenseNumber = request.LicenseNumber,
            LicenseEndAt = request.LicenseEndAt,
            PoaNumber = request.PoaNumber,
            PoaEndAt = request.PoaEndAt,
            ManagerFullName = request.ManagerFullName,
            SeatCount = request.SeatCount,
            OdometrIndicator = request.OdometrIndicator,
            ResponsiblePersonId = request.ResponsiblePersonId,
            Message = request.Message,
            WorkedHours = request.WorkedHours,
            DocDate = DateTime.UtcNow.Date,
            StatusId = StatusIdConst.CREATED
        };

        foreach (var b in request.Batteries)
            entity.Batteries.Add(new TransportSettingBattery
            {
                Quantity = b.Quantity,
                BatteryTypeId = b.BatteryTypeId,
                ProducedAt = b.ProducedAt,
                MileAge = b.MileAge
            });

        foreach (var f in request.Fuels)
            entity.Fuels.Add(new TransportSettingFuel
            {
                FuelTypeId = f.FuelTypeId,
                MonthlyLimit = f.MonthlyLimit,
                Remaining = f.Remaining
            });

        foreach (var i in request.Inspections)
            entity.Inspections.Add(new TransportSettingInspection
            {
                DateAt = i.DateAt,
                ExpireAt = i.ExpireAt,
                ResponsiblePersonId = i.ResponsiblePersonId,
                Details = i.Details,
                NotifyBeforeDay = i.NotifyBeforeDay
            });

        foreach (var ins in request.Insurances)
            entity.Insurances.Add(new TransportSettingInsurance
            {
                InsuranceTypeId = ins.InsuranceTypeId,
                InsNumber = ins.InsNumber,
                ExpireAt = ins.ExpireAt,
                ContractorId = ins.ContractorId,
                ResponsiblePersonId = ins.ResponsiblePersonId,
                Details = ins.Details,
                NotifyBeforeDay = ins.NotifyBeforeDay
            });

        foreach (var l in request.Liquids)
            entity.Liquids.Add(new TransportSettingLiquid
            {
                LiquidTypeId = l.LiquidTypeId,
                TankVolume = l.TankVolume,
                MonthlyLimit = l.MonthlyLimit,
                Remaining = l.Remaining
            });

        foreach (var o in request.Oils)
            entity.Oils.Add(new TransportSettingOil
            {
                OilTypeId = o.OilTypeId,
                MonthlyLimit = o.MonthlyLimit,
                Remaining = o.Remaining
            });

        foreach (var t in request.Tires)
            entity.Tires.Add(new TransportSettingTire
            {
                Quantity = t.Quantity,
                TireSizeId = t.TireSizeId,
                TireModelId = t.TireModelId,
                Size = t.Size,
                ProducedAt = t.ProducedAt,
                MileAge = t.MileAge
            });

        if (request.Files.Any())
        {
            var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                FileStorageConst.TRANSPORT_SETTING_FILE,
                request.Files.Select(x => x.Id).ToArray());
            foreach (var fi in fileInfos)
                entity.Files.Add(new TransportSettingFile { Id = fi.FileId, FileName = fi.FileName });
        }

        await context.TransportSettings.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        if (request.Files.Any())
            await wbStorageService.MoveToPersistentAsync(
                FileStorageConst.TRANSPORT_SETTING_FILE,
                entity.Id.ToString(),
                request.Files.Select(x => x.Id).ToArray());

        await transaction.CommitAsync(cancellationToken);
        return new WbHaveId<long>(entity.Id);
    }
}

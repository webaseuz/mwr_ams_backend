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

internal sealed class UpdateTransportSettingCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<TransportSettingUpdateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(TransportSettingUpdateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var entity = await context.TransportSettings
            .Include(x => x.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Batteries.Where(b => !b.IsDeleted))
            .Include(x => x.Fuels.Where(f => !f.IsDeleted))
            .Include(x => x.Inspections.Where(i => !i.IsDeleted))
            .Include(x => x.Insurances.Where(i => !i.IsDeleted))
            .Include(x => x.Liquids.Where(l => !l.IsDeleted))
            .Include(x => x.Oils.Where(o => !o.IsDeleted))
            .Include(x => x.Tires.Where(t => !t.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.CanTransportSettingStatus(entity.StatusId, StatusIdConst.MODIFIED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_EDITING",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_EDITING").ToString()
                });

        var userInfo = authService.User;

        entity.StatusId = StatusIdConst.MODIFIED;
        entity.TransportId = request.TransportId;
        entity.DriverId = request.DriverId;
        entity.BranchId = request.BranchId ?? userInfo.BranchId ?? 0;
        entity.ManagerId = request.ManagerId;
        entity.LicenseNumber = request.LicenseNumber;
        entity.LicenseEndAt = request.LicenseEndAt;
        entity.PoaNumber = request.PoaNumber;
        entity.PoaEndAt = request.PoaEndAt;
        entity.ManagerFullName = request.ManagerFullName;
        entity.SeatCount = request.SeatCount;
        entity.OdometrIndicator = request.OdometrIndicator;
        entity.ResponsiblePersonId = request.ResponsiblePersonId;
        entity.Message = request.Message;
        entity.WorkedHours = request.WorkedHours;

        // === Files ===
        {
            var requestIds = request.Files.Select(f => f.Id).ToHashSet();
            foreach (var f in entity.Files.Where(f => !requestIds.Contains(f.Id)).ToList())
                f.IsDeleted = true;
            var existingIds = entity.Files.Select(f => f.Id).ToHashSet();
            var newIds = request.Files.Where(f => !existingIds.Contains(f.Id)).Select(f => f.Id).ToArray();
            if (newIds.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.TRANSPORT_SETTING_FILE, newIds);
                foreach (var fi in fileInfos)
                {
                    entity.Files.Add(new TransportSettingFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.TRANSPORT_SETTING_FILE, entity.Id.ToString(), fi.FileId);
                }
            }
        }

        // === Batteries ===
        {
            var reqIds = request.Batteries.Select(b => b.Id).ToHashSet();
            foreach (var row in entity.Batteries.Where(b => !reqIds.Contains(b.Id)).ToList())
                row.IsDeleted = true;
            foreach (var b in request.Batteries.Where(b => b.Id > 0))
            {
                var row = entity.Batteries.FirstOrDefault(x => x.Id == b.Id);
                if (row is null) continue;
                row.Quantity = b.Quantity;
                row.BatteryTypeId = b.BatteryTypeId;
                row.ProducedAt = b.ProducedAt;
                row.MileAge = b.MileAge;
            }
            foreach (var b in request.Batteries.Where(b => b.Id == 0))
                entity.Batteries.Add(new TransportSettingBattery
                {
                    Quantity = b.Quantity,
                    BatteryTypeId = b.BatteryTypeId,
                    ProducedAt = b.ProducedAt,
                    MileAge = b.MileAge
                });
        }

        // === Fuels ===
        {
            var reqIds = request.Fuels.Select(f => f.Id).ToHashSet();
            foreach (var row in entity.Fuels.Where(f => !reqIds.Contains(f.Id)).ToList())
                row.IsDeleted = true;
            foreach (var f in request.Fuels.Where(f => f.Id > 0))
            {
                var row = entity.Fuels.FirstOrDefault(x => x.Id == f.Id);
                if (row is null) continue;
                row.FuelTypeId = f.FuelTypeId;
                row.MonthlyLimit = f.MonthlyLimit;
                row.Remaining = f.Remaining;
            }
            foreach (var f in request.Fuels.Where(f => f.Id == 0))
                entity.Fuels.Add(new TransportSettingFuel
                {
                    FuelTypeId = f.FuelTypeId,
                    MonthlyLimit = f.MonthlyLimit,
                    Remaining = f.Remaining
                });
        }

        // === Inspections ===
        {
            var reqIds = request.Inspections.Select(i => i.Id).ToHashSet();
            foreach (var row in entity.Inspections.Where(i => !reqIds.Contains(i.Id)).ToList())
                row.IsDeleted = true;
            foreach (var i in request.Inspections.Where(i => i.Id > 0))
            {
                var row = entity.Inspections.FirstOrDefault(x => x.Id == i.Id);
                if (row is null) continue;
                row.DateAt = i.DateAt;
                row.ExpireAt = i.ExpireAt;
                row.ResponsiblePersonId = i.ResponsiblePersonId;
                row.Details = i.Details;
                row.NotifyBeforeDay = i.NotifyBeforeDay;
            }
            foreach (var i in request.Inspections.Where(i => i.Id == 0))
                entity.Inspections.Add(new TransportSettingInspection
                {
                    DateAt = i.DateAt,
                    ExpireAt = i.ExpireAt,
                    ResponsiblePersonId = i.ResponsiblePersonId,
                    Details = i.Details,
                    NotifyBeforeDay = i.NotifyBeforeDay
                });
        }

        // === Insurances ===
        {
            var reqIds = request.Insurances.Select(ins => ins.Id).ToHashSet();
            foreach (var row in entity.Insurances.Where(ins => !reqIds.Contains(ins.Id)).ToList())
                row.IsDeleted = true;
            foreach (var ins in request.Insurances.Where(ins => ins.Id > 0))
            {
                var row = entity.Insurances.FirstOrDefault(x => x.Id == ins.Id);
                if (row is null) continue;
                row.InsuranceTypeId = ins.InsuranceTypeId;
                row.InsNumber = ins.InsNumber;
                row.ExpireAt = ins.ExpireAt;
                row.ContractorId = ins.ContractorId;
                row.ResponsiblePersonId = ins.ResponsiblePersonId;
                row.Details = ins.Details;
                row.NotifyBeforeDay = ins.NotifyBeforeDay;
            }
            foreach (var ins in request.Insurances.Where(ins => ins.Id == 0))
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
        }

        // === Liquids ===
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
                row.MonthlyLimit = l.MonthlyLimit;
                row.Remaining = l.Remaining;
            }
            foreach (var l in request.Liquids.Where(l => l.Id == 0))
                entity.Liquids.Add(new TransportSettingLiquid
                {
                    LiquidTypeId = l.LiquidTypeId,
                    TankVolume = l.TankVolume,
                    MonthlyLimit = l.MonthlyLimit,
                    Remaining = l.Remaining
                });
        }

        // === Oils ===
        {
            var reqIds = request.Oils.Select(o => o.Id).ToHashSet();
            foreach (var row in entity.Oils.Where(o => !reqIds.Contains(o.Id)).ToList())
                row.IsDeleted = true;
            foreach (var o in request.Oils.Where(o => o.Id > 0))
            {
                var row = entity.Oils.FirstOrDefault(x => x.Id == o.Id);
                if (row is null) continue;
                row.OilTypeId = o.OilTypeId;
                row.MonthlyLimit = o.MonthlyLimit;
                row.Remaining = o.Remaining;
            }
            foreach (var o in request.Oils.Where(o => o.Id == 0))
                entity.Oils.Add(new TransportSettingOil
                {
                    OilTypeId = o.OilTypeId,
                    MonthlyLimit = o.MonthlyLimit,
                    Remaining = o.Remaining
                });
        }

        // === Tires ===
        {
            var reqIds = request.Tires.Select(t => t.Id).ToHashSet();
            foreach (var row in entity.Tires.Where(t => !reqIds.Contains(t.Id)).ToList())
                row.IsDeleted = true;
            foreach (var t in request.Tires.Where(t => t.Id > 0))
            {
                var row = entity.Tires.FirstOrDefault(x => x.Id == t.Id);
                if (row is null) continue;
                row.TireSizeId = t.TireSizeId;
                row.TireModelId = t.TireModelId;
                row.Quantity = t.Quantity;
                row.Size = t.Size;
                row.ProducedAt = t.ProducedAt;
                row.MileAge = t.MileAge;
            }
            foreach (var t in request.Tires.Where(t => t.Id == 0))
                entity.Tires.Add(new TransportSettingTire
                {
                    TireSizeId = t.TireSizeId,
                    TireModelId = t.TireModelId,
                    Quantity = t.Quantity,
                    Size = t.Size,
                    ProducedAt = t.ProducedAt,
                    MileAge = t.MileAge
                });
        }

        await context.SaveChangesAsync(cancellationToken);

        await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.TRANSPORT_SETTING_FILE, entity.Id.ToString());

        await transaction.CommitAsync(cancellationToken);
        return new WbHaveId<long>(entity.Id);
    }
}

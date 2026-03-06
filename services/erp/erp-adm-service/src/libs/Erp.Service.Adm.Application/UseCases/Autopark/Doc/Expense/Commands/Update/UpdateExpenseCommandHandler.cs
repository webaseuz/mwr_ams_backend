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

internal sealed class UpdateExpenseCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<ExpenseUpdateCommand, bool>
{
    public async Task<bool> Handle(ExpenseUpdateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        var entity = await context.Expenses
            .Include(x => x.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Batteries.Where(b => !b.IsDeleted)).ThenInclude(b => b.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Insurances.Where(b => !b.IsDeleted)).ThenInclude(b => b.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Inspections.Where(b => !b.IsDeleted)).ThenInclude(b => b.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Liquids.Where(b => !b.IsDeleted)).ThenInclude(b => b.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Oils.Where(b => !b.IsDeleted)).ThenInclude(b => b.Files.Where(f => !f.IsDeleted))
            .Include(x => x.Tires.Where(b => !b.IsDeleted)).ThenInclude(b => b.Files.Where(f => !f.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
               .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
               .WithErrors(new WbFailure
               {
                   Key = "DOCUMENT_NOT_FOUND",
                   ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
               });

        var userInfo = authService.User;

        if (userInfo.Permissions.Contains(nameof(AutoparkPermissionCode.InvoiceAttach)) && StatusIdConst.CanInvoice(entity.StatusId))
        {
            request.Batteries?.ForEach(b =>
            {
                var row = entity.Batteries.FirstOrDefault(x => x.Id == b.Id);
                if (row is not null) { row.InvoiceNumber = b.InvoiceNumber; row.InvoiceDateOn = b.InvoiceDateOn; }
            });
            request.Inspections?.ForEach(i =>
            {
                var row = entity.Inspections.FirstOrDefault(x => x.Id == i.Id);
                if (row is not null) { row.InvoiceNumber = i.InvoiceNumber; row.InvoiceDateOn = i.InvoiceDateOn; }
            });
            request.Insurances?.ForEach(ins =>
            {
                var row = entity.Insurances.FirstOrDefault(x => x.Id == ins.Id);
                if (row is not null) { row.InvoiceNumber = ins.InvoiceNumber; row.InvoiceDateOn = ins.InvoiceDateOn; }
            });
            request.Liquids?.ForEach(l =>
            {
                var row = entity.Liquids.FirstOrDefault(x => x.Id == l.Id);
                if (row is not null) { row.InvoiceNumber = l.InvoiceNumber; row.InvoiceDateOn = l.InvoiceDateOn; }
            });
            request.Oils?.ForEach(o =>
            {
                var row = entity.Oils.FirstOrDefault(x => x.Id == o.Id);
                if (row is not null) { row.InvoiceNumber = o.InvoiceNumber; row.InvoiceDateOn = o.InvoiceDateOn; }
            });
            request.Tires?.ForEach(t =>
            {
                var row = entity.Tires.FirstOrDefault(x => x.Id == t.Id);
                if (row is not null) { row.InvoiceNumber = t.InvoiceNumber; row.InvoiceDateOn = t.InvoiceDateOn; }
            });

            await context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            if (!StatusIdConst.CanExpenseStatus(entity.StatusId, StatusIdConst.MODIFIED))
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "STATUS_NOT_ALLOWED_FOR_EDITING",
                        ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_EDITING").ToString()
                    });

            entity.StatusId = StatusIdConst.MODIFIED;
            entity.DocDate = request.DocDate;
            entity.TransportId = request.TransportId;
            entity.DriverId = request.DriverId;
            entity.BranchId = request.BranchId;
            entity.Message = request.Message;

            if (!userInfo.Permissions.Contains(nameof(AutoparkPermissionCode.ExpenseCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            // === Main Files ===
            {
                var requestIds = request.Files.Select(f => f.Id).ToHashSet();
                foreach (var f in entity.Files.Where(f => !requestIds.Contains(f.Id)).ToList())
                    f.IsDeleted = true;
                var existingIds = entity.Files.Select(f => f.Id).ToHashSet();
                var newIds = request.Files.Where(f => !existingIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                if (newIds.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_FILE, newIds);
                    foreach (var fi in fileInfos)
                    {
                        entity.Files.Add(new ExpenseFile { Id = fi.FileId, FileName = fi.FileName });
                        await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_FILE, entity.Id.ToString(), fi.FileId);
                    }
                }
            }

            // === Batteries ===
            var newBatteriesForFiles = new List<(ExpenseBattery row, ExpenseBatteryUpdateCommand cmd)>();
            {
                var reqIds = request.Batteries.Select(b => b.Id).ToHashSet();
                foreach (var row in entity.Batteries.Where(b => !reqIds.Contains(b.Id)).ToList())
                    row.IsDeleted = true;
                foreach (var b in request.Batteries.Where(b => b.Id > 0))
                {
                    var row = entity.Batteries.FirstOrDefault(x => x.Id == b.Id);
                    if (row is null) continue;
                    row.BatteryTypeId = b.BatteryTypeId;
                    row.DateOn = b.DateOn;
                    row.Quantity = b.Quantity;
                    row.Price = b.Price;
                    row.TotalPrice = b.TotalPrice;
                    row.MileAge = b.MileAge;
                    row.InvoiceNumber = b.InvoiceNumber;
                    row.InvoiceDateOn = b.InvoiceDateOn;

                    var reqFileIds = b.Files.Select(f => f.Id).ToHashSet();
                    foreach (var f in row.Files.Where(f => !reqFileIds.Contains(f.Id)).ToList())
                        f.IsDeleted = true;
                    var existFileIds = row.Files.Select(f => f.Id).ToHashSet();
                    var newFileIds = b.Files.Where(f => !existFileIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                    if (newFileIds.Any())
                    {
                        var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_BATTERY_FILE, newFileIds);
                        foreach (var fi in fileInfos)
                        {
                            row.Files.Add(new ExpenseBatteryFile { Id = fi.FileId, FileName = fi.FileName });
                            await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_BATTERY_FILE, row.Id.ToString(), fi.FileId);
                        }
                    }
                }
                foreach (var b in request.Batteries.Where(b => b.Id == 0))
                {
                    var row = new ExpenseBattery
                    {
                        BatteryTypeId = b.BatteryTypeId,
                        DateOn = b.DateOn,
                        Quantity = b.Quantity,
                        Price = b.Price,
                        TotalPrice = b.TotalPrice,
                        MileAge = b.MileAge,
                        InvoiceNumber = b.InvoiceNumber,
                        InvoiceDateOn = b.InvoiceDateOn,
                    };
                    entity.Batteries.Add(row);
                    if (b.Files.Any()) newBatteriesForFiles.Add((row, b));
                }
            }

            // === Inspections ===
            var newInspectionsForFiles = new List<(ExpenseInspection row, ExpenseInspectionUpdateCommand cmd)>();
            {
                var reqIds = request.Inspections.Select(i => i.Id).ToHashSet();
                foreach (var row in entity.Inspections.Where(i => !reqIds.Contains(i.Id)).ToList())
                    row.IsDeleted = true;
                foreach (var i in request.Inspections.Where(i => i.Id > 0))
                {
                    var row = entity.Inspections.FirstOrDefault(x => x.Id == i.Id);
                    if (row is null) continue;
                    row.InspectionTypeId = i.InspectionTypeId;
                    row.DateOn = i.DateOn;
                    row.Details = i.Details;
                    row.Price = i.Price;
                    row.MileAge = i.MileAge;
                    row.InvoiceNumber = i.InvoiceNumber;
                    row.InvoiceDateOn = i.InvoiceDateOn;

                    var reqFileIds = i.Files.Select(f => f.Id).ToHashSet();
                    foreach (var f in row.Files.Where(f => !reqFileIds.Contains(f.Id)).ToList())
                        f.IsDeleted = true;
                    var existFileIds = row.Files.Select(f => f.Id).ToHashSet();
                    var newFileIds = i.Files.Where(f => !existFileIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                    if (newFileIds.Any())
                    {
                        var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_INCPECTION_FILE, newFileIds);
                        foreach (var fi in fileInfos)
                        {
                            row.Files.Add(new ExpenseInspectionFile { Id = fi.FileId, FileName = fi.FileName });
                            await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_INCPECTION_FILE, row.Id.ToString(), fi.FileId);
                        }
                    }
                }
                foreach (var i in request.Inspections.Where(i => i.Id == 0))
                {
                    var row = new ExpenseInspection
                    {
                        InspectionTypeId = i.InspectionTypeId,
                        DateOn = i.DateOn,
                        Details = i.Details,
                        Price = i.Price,
                        MileAge = i.MileAge,
                        InvoiceNumber = i.InvoiceNumber,
                        InvoiceDateOn = i.InvoiceDateOn,
                    };
                    entity.Inspections.Add(row);
                    if (i.Files.Any()) newInspectionsForFiles.Add((row, i));
                }
            }

            // === Insurances ===
            var newInsurancesForFiles = new List<(ExpenseInsurance row, ExpenseInsuranceUpdateCommand cmd)>();
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
                    row.DateOn = ins.DateOn;
                    row.ContractorId = ins.ContractorId;
                    row.Price = ins.Price;
                    row.InvoiceNumber = ins.InvoiceNumber;
                    row.InvoiceDateOn = ins.InvoiceDateOn;

                    var reqFileIds = ins.Files.Select(f => f.Id).ToHashSet();
                    foreach (var f in row.Files.Where(f => !reqFileIds.Contains(f.Id)).ToList())
                        f.IsDeleted = true;
                    var existFileIds = row.Files.Select(f => f.Id).ToHashSet();
                    var newFileIds = ins.Files.Where(f => !existFileIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                    if (newFileIds.Any())
                    {
                        var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_INSURANCE_FILE, newFileIds);
                        foreach (var fi in fileInfos)
                        {
                            row.Files.Add(new ExpenseInsuranceFile { Id = fi.FileId, FileName = fi.FileName });
                            await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_INSURANCE_FILE, row.Id.ToString(), fi.FileId);
                        }
                    }
                }
                foreach (var ins in request.Insurances.Where(ins => ins.Id == 0))
                {
                    var row = new ExpenseInsurance
                    {
                        InsuranceTypeId = ins.InsuranceTypeId,
                        InsNumber = ins.InsNumber,
                        DateOn = ins.DateOn,
                        ContractorId = ins.ContractorId,
                        Price = ins.Price,
                        InvoiceNumber = ins.InvoiceNumber,
                        InvoiceDateOn = ins.InvoiceDateOn,
                    };
                    entity.Insurances.Add(row);
                    if (ins.Files.Any()) newInsurancesForFiles.Add((row, ins));
                }
            }

            // === Liquids ===
            var newLiquidsForFiles = new List<(ExpenseLiquid row, ExpenseLiquidUpdateCommand cmd)>();
            {
                var reqIds = request.Liquids.Select(l => l.Id).ToHashSet();
                foreach (var row in entity.Liquids.Where(l => !reqIds.Contains(l.Id)).ToList())
                    row.IsDeleted = true;
                foreach (var l in request.Liquids.Where(l => l.Id > 0))
                {
                    var row = entity.Liquids.FirstOrDefault(x => x.Id == l.Id);
                    if (row is null) continue;
                    row.LiquidTypeId = l.LiquidTypeId;
                    row.DateOn = l.DateOn;
                    row.Quantity = l.Quantity;
                    row.Price = l.Price;
                    row.TotalPrice = l.TotalPrice;
                    row.MileAge = l.MileAge;
                    row.InvoiceNumber = l.InvoiceNumber;
                    row.InvoiceDateOn = l.InvoiceDateOn;

                    var reqFileIds = l.Files.Select(f => f.Id).ToHashSet();
                    foreach (var f in row.Files.Where(f => !reqFileIds.Contains(f.Id)).ToList())
                        f.IsDeleted = true;
                    var existFileIds = row.Files.Select(f => f.Id).ToHashSet();
                    var newFileIds = l.Files.Where(f => !existFileIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                    if (newFileIds.Any())
                    {
                        var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_LIQUID_FILE, newFileIds);
                        foreach (var fi in fileInfos)
                        {
                            row.Files.Add(new ExpenseLiquidFile { Id = fi.FileId, FileName = fi.FileName });
                            await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_LIQUID_FILE, row.Id.ToString(), fi.FileId);
                        }
                    }
                }
                foreach (var l in request.Liquids.Where(l => l.Id == 0))
                {
                    var row = new ExpenseLiquid
                    {
                        LiquidTypeId = l.LiquidTypeId,
                        DateOn = l.DateOn,
                        Quantity = l.Quantity,
                        Price = l.Price,
                        TotalPrice = l.TotalPrice,
                        MileAge = l.MileAge,
                        InvoiceNumber = l.InvoiceNumber,
                        InvoiceDateOn = l.InvoiceDateOn,
                    };
                    entity.Liquids.Add(row);
                    if (l.Files.Any()) newLiquidsForFiles.Add((row, l));
                }
            }

            // === Oils ===
            var newOilsForFiles = new List<(ExpenseOil row, ExpenseOilUpdateCommand cmd)>();
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
                    row.DateOn = o.DateOn;
                    row.Quantity = o.Quantity;
                    row.Price = o.Price;
                    row.TotalPrice = o.TotalPrice;
                    row.MileAge = o.MileAge;
                    row.InvoiceNumber = o.InvoiceNumber;
                    row.InvoiceDateOn = o.InvoiceDateOn;

                    var reqFileIds = o.Files.Select(f => f.Id).ToHashSet();
                    foreach (var f in row.Files.Where(f => !reqFileIds.Contains(f.Id)).ToList())
                        f.IsDeleted = true;
                    var existFileIds = row.Files.Select(f => f.Id).ToHashSet();
                    var newFileIds = o.Files.Where(f => !existFileIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                    if (newFileIds.Any())
                    {
                        var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_OIL_FILE, newFileIds);
                        foreach (var fi in fileInfos)
                        {
                            row.Files.Add(new ExpenseOilFile { Id = fi.FileId, FileName = fi.FileName });
                            await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_OIL_FILE, row.Id.ToString(), fi.FileId);
                        }
                    }
                }
                foreach (var o in request.Oils.Where(o => o.Id == 0))
                {
                    var row = new ExpenseOil
                    {
                        OilTypeId = o.OilTypeId,
                        OilModelId = o.OilModelId,
                        DateOn = o.DateOn,
                        Quantity = o.Quantity,
                        Price = o.Price,
                        TotalPrice = o.TotalPrice,
                        MileAge = o.MileAge,
                        InvoiceNumber = o.InvoiceNumber,
                        InvoiceDateOn = o.InvoiceDateOn,
                    };
                    entity.Oils.Add(row);
                    if (o.Files.Any()) newOilsForFiles.Add((row, o));
                }
            }

            // === Tires ===
            var newTiresForFiles = new List<(ExpenseTire row, ExpenseTireUpdateCommand cmd)>();
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
                    row.DateOn = t.DateOn;
                    row.Quantity = t.Quantity;
                    row.Price = t.Price;
                    row.TotalPrice = t.TotalPrice;
                    row.MileAge = t.MileAge;
                    row.InvoiceNumber = t.InvoiceNumber;
                    row.InvoiceDateOn = t.InvoiceDateOn;

                    var reqFileIds = t.Files.Select(f => f.Id).ToHashSet();
                    foreach (var f in row.Files.Where(f => !reqFileIds.Contains(f.Id)).ToList())
                        f.IsDeleted = true;
                    var existFileIds = row.Files.Select(f => f.Id).ToHashSet();
                    var newFileIds = t.Files.Where(f => !existFileIds.Contains(f.Id)).Select(f => f.Id).ToArray();
                    if (newFileIds.Any())
                    {
                        var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_TIRE_FILE, newFileIds);
                        foreach (var fi in fileInfos)
                        {
                            row.Files.Add(new ExpenseTireFile { Id = fi.FileId, FileName = fi.FileName });
                            await wbStorageService.MarkFileForMoveToPersistentAsync(FileStorageConst.EXPENSE_TIRE_FILE, row.Id.ToString(), fi.FileId);
                        }
                    }
                }
                foreach (var t in request.Tires.Where(t => t.Id == 0))
                {
                    var row = new ExpenseTire
                    {
                        TireSizeId = t.TireSizeId,
                        TireModelId = t.TireModelId,
                        DateOn = t.DateOn,
                        Quantity = t.Quantity,
                        Price = t.Price,
                        TotalPrice = t.TotalPrice,
                        MileAge = t.MileAge,
                        InvoiceNumber = t.InvoiceNumber,
                        InvoiceDateOn = t.InvoiceDateOn,
                    };
                    entity.Tires.Add(row);
                    if (t.Files.Any()) newTiresForFiles.Add((row, t));
                }
            }

            // Save: persists all changes and assigns IDs to new rows
            await context.SaveChangesAsync(cancellationToken);

            // Files for new rows (IDs are now available)
            foreach (var (row, b) in newBatteriesForFiles)
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_BATTERY_FILE, b.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                {
                    row.Files.Add(new ExpenseBatteryFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MoveToPersistentAsync(FileStorageConst.EXPENSE_BATTERY_FILE, row.Id.ToString(), fi.FileId);
                }
            }
            foreach (var (row, i) in newInspectionsForFiles)
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_INCPECTION_FILE, i.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                {
                    row.Files.Add(new ExpenseInspectionFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MoveToPersistentAsync(FileStorageConst.EXPENSE_INCPECTION_FILE, row.Id.ToString(), fi.FileId);
                }
            }
            foreach (var (row, ins) in newInsurancesForFiles)
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_INSURANCE_FILE, ins.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                {
                    row.Files.Add(new ExpenseInsuranceFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MoveToPersistentAsync(FileStorageConst.EXPENSE_INSURANCE_FILE, row.Id.ToString(), fi.FileId);
                }
            }
            foreach (var (row, l) in newLiquidsForFiles)
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_LIQUID_FILE, l.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                {
                    row.Files.Add(new ExpenseLiquidFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MoveToPersistentAsync(FileStorageConst.EXPENSE_LIQUID_FILE, row.Id.ToString(), fi.FileId);
                }
            }
            foreach (var (row, o) in newOilsForFiles)
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_OIL_FILE, o.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                {
                    row.Files.Add(new ExpenseOilFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MoveToPersistentAsync(FileStorageConst.EXPENSE_OIL_FILE, row.Id.ToString(), fi.FileId);
                }
            }
            foreach (var (row, t) in newTiresForFiles)
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(FileStorageConst.EXPENSE_TIRE_FILE, t.Files.Select(f => f.Id).ToArray());
                foreach (var fi in fileInfos)
                {
                    row.Files.Add(new ExpenseTireFile { Id = fi.FileId, FileName = fi.FileName });
                    await wbStorageService.MoveToPersistentAsync(FileStorageConst.EXPENSE_TIRE_FILE, row.Id.ToString(), fi.FileId);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        await TableFileResolve(entity);
        await transaction.CommitAsync(cancellationToken);
        return true;
    }

    private async Task TableFileResolve(Expense entity)
    {
        await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_FILE, entity.Id.ToString());
        foreach (var item in entity.Batteries)
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_BATTERY_FILE, item.Id.ToString());
        foreach (var item in entity.Inspections)
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_INCPECTION_FILE, item.Id.ToString());
        foreach (var item in entity.Insurances)
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_INSURANCE_FILE, item.Id.ToString());
        foreach (var item in entity.Oils)
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_OIL_FILE, item.Id.ToString());
        foreach (var item in entity.Liquids)
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_LIQUID_FILE, item.Id.ToString());
        foreach (var item in entity.Tires)
            await wbStorageService.ResolveMarkedFilesAsync(FileStorageConst.EXPENSE_TIRE_FILE, item.Id.ToString());
    }
}

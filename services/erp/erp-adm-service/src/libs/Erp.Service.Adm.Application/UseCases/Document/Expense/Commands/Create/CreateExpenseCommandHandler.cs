using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateExpenseCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService,
    IWbStorageService wbStorageService) : IRequestHandler<ExpenseCreateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(ExpenseCreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = new Expense
            {
                DocDate = request.DocDate,
                TransportId = request.TransportId,
                DriverId = request.DriverId,
                BranchId = request.BranchId,
                Message = request.Message,
                StatusId = StatusIdConst.CREATED
            };

            var userInfo = authService.User;
            if (!userInfo.Permissions.Contains(nameof(PermissionCode.ExpenseCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            foreach (var b in request.Batteries)
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
                if (b.Files.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                        FileStorageConst.EXPENSE_BATTERY_FILE,
                        b.Files.Select(f => f.Id).ToArray());
                    foreach (var fi in fileInfos)
                        row.Files.Add(new ExpenseBatteryFile { Id = fi.FileId, FileName = fi.FileName });
                }
                entity.Batteries.Add(row);
            }

            foreach (var i in request.Inspections)
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
                if (i.Files.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                        FileStorageConst.EXPENSE_INCPECTION_FILE,
                        i.Files.Select(f => f.Id).ToArray());
                    foreach (var fi in fileInfos)
                        row.Files.Add(new ExpenseInspectionFile { Id = fi.FileId, FileName = fi.FileName });
                }
                entity.Inspections.Add(row);
            }

            foreach (var ins in request.Insurances)
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
                if (ins.Files.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                        FileStorageConst.EXPENSE_INSURANCE_FILE,
                        ins.Files.Select(f => f.Id).ToArray());
                    foreach (var fi in fileInfos)
                        row.Files.Add(new ExpenseInsuranceFile { Id = fi.FileId, FileName = fi.FileName });
                }
                entity.Insurances.Add(row);
            }

            foreach (var l in request.Liquids)
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
                if (l.Files.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                        FileStorageConst.EXPENSE_LIQUID_FILE,
                        l.Files.Select(f => f.Id).ToArray());
                    foreach (var fi in fileInfos)
                        row.Files.Add(new ExpenseLiquidFile { Id = fi.FileId, FileName = fi.FileName });
                }
                entity.Liquids.Add(row);
            }

            foreach (var o in request.Oils)
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
                if (o.Files.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                        FileStorageConst.EXPENSE_OIL_FILE,
                        o.Files.Select(f => f.Id).ToArray());
                    foreach (var fi in fileInfos)
                        row.Files.Add(new ExpenseOilFile { Id = fi.FileId, FileName = fi.FileName });
                }
                entity.Oils.Add(row);
            }

            foreach (var t in request.Tires)
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
                if (t.Files.Any())
                {
                    var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                        FileStorageConst.EXPENSE_TIRE_FILE,
                        t.Files.Select(f => f.Id).ToArray());
                    foreach (var fi in fileInfos)
                        row.Files.Add(new ExpenseTireFile { Id = fi.FileId, FileName = fi.FileName });
                }
                entity.Tires.Add(row);
            }

            if (request.Files.Any())
            {
                var fileInfos = await wbStorageService.GetTempFileInfosAsync(
                    FileStorageConst.EXPENSE_FILE,
                    request.Files.Select(x => x.Id).ToArray());
                foreach (var fi in fileInfos)
                    entity.Files.Add(new ExpenseFile { Id = fi.FileId, FileName = fi.FileName });
            }

            await context.Expenses.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            if (request.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_FILE,
                    entity.Id.ToString(),
                    request.Files.Select(x => x.Id).ToArray());

            await TableFileResolve(entity);

            await transaction.CommitAsync(cancellationToken);

            return new WbHaveId<long>(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private async Task TableFileResolve(Expense entity)
    {
        foreach (var item in entity.Batteries)
        {
            if (item.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_BATTERY_FILE,
                    item.Id.ToString(),
                    item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Inspections)
        {
            if (item.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_INCPECTION_FILE,
                    item.Id.ToString(),
                    item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Insurances)
        {
            if (item.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_INSURANCE_FILE,
                    item.Id.ToString(),
                    item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Oils)
        {
            if (item.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_OIL_FILE,
                    item.Id.ToString(),
                    item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Liquids)
        {
            if (item.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_LIQUID_FILE,
                    item.Id.ToString(),
                    item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Tires)
        {
            if (item.Files.Any())
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.EXPENSE_TIRE_FILE,
                    item.Id.ToString(),
                    item.Files.Select(x => x.Id).ToArray());
        }
    }
}

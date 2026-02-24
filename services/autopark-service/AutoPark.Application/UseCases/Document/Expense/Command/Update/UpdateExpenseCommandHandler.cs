using AutoPark.Application.Security;
using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseCommandHandler :
    IRequestHandler<UpdateExpenseCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IAsyncAppAuthService _authService;
    public UpdateExpenseCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
        UpdateExpenseCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _context.Expenses
                .Include(x => x.Files)
                .Include(x => x.Batteries)
                    .ThenInclude(b => b.Files)
                .Include(x => x.Insurances)
                    .ThenInclude(b => b.Files)
                .Include(x => x.Inspections)
                    .ThenInclude(b => b.Files)
                .Include(x => x.Liquids)
                    .ThenInclude(b => b.Files)
                .Include(x => x.Oils)
                    .ThenInclude(b => b.Files)
                .Include(x => x.Tires)
                    .ThenInclude(b => b.Files)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            var userInfo = await _authService.GetUserAsync();

            if (userInfo.Permissions.Contains(nameof(PermissionCode.InvoiceAttach)) && StatusIdConst.CanInvoice(entity.StatusId))
            {
                request.Batteries?.ForEach(b =>
                {
                    var row = entity.Batteries.FirstOrDefault(x => x.Id == b.Id);

                    if (row is not null)
                    {
                        row.InvoiceNumber = b.InvoiceNumber;
                        row.InvoiceDateOn = b.InvoiceDateOn;
                    }
                });

                request.Inspections?.ForEach(b =>
                {
                    var row = entity.Inspections.FirstOrDefault(x => x.Id == b.Id);

                    if (row is not null)
                    {
                        row.InvoiceNumber = b.InvoiceNumber;
                        row.InvoiceDateOn = b.InvoiceDateOn;
                    }
                });

                request.Insurances?.ForEach(b =>
                {
                    var row = entity.Insurances.FirstOrDefault(x => x.Id == b.Id);

                    if (row is not null)
                    {
                        row.InvoiceNumber = b.InvoiceNumber;
                        row.InvoiceDateOn = b.InvoiceDateOn;
                    }
                });

                request.Liquids?.ForEach(b =>
                {
                    var row = entity.Liquids.FirstOrDefault(x => x.Id == b.Id);

                    if (row is not null)
                    {
                        row.InvoiceNumber = b.InvoiceNumber;
                        row.InvoiceDateOn = b.InvoiceDateOn;
                    }
                });

                request.Oils?.ForEach(b =>
                {
                    var row = entity.Oils.FirstOrDefault(x => x.Id == b.Id);

                    if (row is not null)
                    {
                        row.InvoiceNumber = b.InvoiceNumber;
                        row.InvoiceDateOn = b.InvoiceDateOn;
                    }
                });

                request.Tires?.ForEach(b =>
                {
                    var row = entity.Tires.FirstOrDefault(x => x.Id == b.Id);

                    if (row is not null)
                    {
                        row.InvoiceNumber = b.InvoiceNumber;
                        row.InvoiceDateOn = b.InvoiceDateOn;
                    }
                });
            }
            else
            {
                entity.Update();


                if (!userInfo.Permissions.Contains(nameof(PermissionCode.ExpenseCreateForAllBranch)) || !request.BranchId.HasValue)
                    entity.BranchId = userInfo.BranchId;

                entity.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_FILE,
                                             documentId: entity.Id.ToString(),
                                             files: request.Files.Select(x => x.Id).ToList(),
                                             context: _context);

                request.UpdateEntity(entity, _mapper);

                #region Set Tables
                request.Batteries.ApplyChangesTo<long, UpdateExpenseBatteryCommand, ExpenseBattery>(
                    entity.Batteries,
                    _mapper,
                    onUpdateFromNavigationProperty: (e, d) => e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context),
                    onAddToNavigationProperty: (e, d) =>
                    {
                        _context.SaveChanges(true);
                        e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context);
                    });

                request.Inspections.ApplyChangesTo<long, UpdateExpenseInspectionCommand, ExpenseInspection>(
                    entity.Inspections,
                    _mapper,
                    onUpdateFromNavigationProperty: (e, d) => e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_INCPECTION_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context),
                    onAddToNavigationProperty: (e, d) =>
                    {
                        _context.SaveChanges(true);
                        e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_INCPECTION_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context);
                    });

                request.Insurances.ApplyChangesTo<long, UpdateExpenseInsuranceCommand, ExpenseInsurance>(
                    entity.Insurances,
                    _mapper,
                    onUpdateFromNavigationProperty: (e, d) => e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_INSURANCE_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context),
                    onAddToNavigationProperty: (e, d) =>
                    {
                        _context.SaveChanges(true);
                        e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_INSURANCE_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context);
                    });

                request.Liquids.ApplyChangesTo<long, UpdateExpenseLiquidCommand, ExpenseLiquid>(
                    entity.Liquids,
                    _mapper,
                    onUpdateFromNavigationProperty: (e, d) => e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_LIQUID_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context),
                    onAddToNavigationProperty: (e, d) =>
                    {
                        _context.SaveChanges(true);
                        e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_LIQUID_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context);
                    });

                request.Oils.ApplyChangesTo<long, UpdateExpenseOilCommand, ExpenseOil>(
                    entity.Oils,
                    _mapper,
                    onUpdateFromNavigationProperty: (e, d) => e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_OIL_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context),
                    onAddToNavigationProperty: (e, d) =>
                    {
                        _context.SaveChanges(true);
                        e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_OIL_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context);
                    });

                request.Tires.ApplyChangesTo<long, UpdateExpenseTireCommand, ExpenseTire>(
                    entity.Tires,
                    _mapper,
                    onUpdateFromNavigationProperty: (e, d) => e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context),
                    onAddToNavigationProperty: (e, d) =>
                    {
                        _context.SaveChanges(true);
                        e.Files.UpdateFromFiles(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                          documentId: e.Id.ToString(),
                                          files: d.Files.Select(f => f.Id).ToList(),
                                          context: _context);
                    });
                #endregion

                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_FILE,
                                                                  documentId: request.Id.ToString());


                request.UpdateEntity(entity, _mapper);

            }

            await _context.SaveChangesAsync(cancellationToken);
            await TableFileResolve(entity);

            try
            {
                var entityById = await _mapper.MapCollection<Expense, ExpenseDto>(_context.Expenses)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, Expense, ExpenseDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.EXPENSE_HISTORY,
                                                                         documentId: entity.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            await transaction.CommitAsync(cancellationToken);
            return HaveId.Create(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
    private async Task TableFileResolve(Expense request)
    {
        foreach (var item in request.Batteries)
        {
            if (item.Files.Any())
            {
                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                                               documentId: item.Id.ToString());
            }
        }
        foreach (var item in request.Inspections)
        {
            if (item.Files.Any())
                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_INCPECTION_FILE,
                                                               documentId: item.Id.ToString());
        }
        foreach (var item in request.Insurances)
        {
            if (item.Files.Any())
                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_INSURANCE_FILE,
                                                               documentId: item.Id.ToString());
        }
        foreach (var item in request.Oils)
        {
            if (item.Files.Any())
                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_OIL_FILE,
                                                               documentId: item.Id.ToString());
        }
        foreach (var item in request.Liquids)
        {
            if (item.Files.Any())
                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_LIQUID_FILE,
                                                               documentId: item.Id.ToString());
        }
        foreach (var item in request.Tires)
        {
            if (item.Files.Any())
                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.EXPENSE_TIRE_FILE,
                                                               documentId: item.Id.ToString());
        }
    }
}

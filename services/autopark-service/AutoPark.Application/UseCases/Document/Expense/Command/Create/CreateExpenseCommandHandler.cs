using AutoPark.Application.Security;
using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseCommandHandler :
    IRequestHandler<CreateExpenseCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public CreateExpenseCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        INumberService numberService,
        IStorageAsyncService storageAsyncService,
        IAsyncAppAuthService authService,
        IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _numberService = numberService;
        _storageAsyncService = storageAsyncService;
        _authService = authService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(CreateExpenseCommand request,
                                      CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // Generate the next available document number for the expense
            var docNumberResult = _numberService.GetNext(NumberTamplateDocumentConst.Expense);

            // Map the request data to the Expense entity
            var entity = request.CreateEntity<CreateExpenseCommand, Expense>(_mapper);

            // Assign the generated document number
            entity.DocNumber = docNumberResult.docNumber;

            var userInfo = await _authService.GetUserAsync();
            if (!userInfo.Permissions.Contains(nameof(PermissionCode.RefuelCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            // Set default creation values (timestamps, etc.)
            entity.Create();

            #region Set Tables
            // set document child entities
            request.Batteries.AddTo(entity.Batteries, _mapper,
                                    (e, d) => e.Files.AddFromTempFiles(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                                                      tempFileIds: d.Files.Select(f => f.Id)
                                                                                          .ToList()));
            request.Inspections.AddTo(entity.Inspections, _mapper,
                                    (e, d) => e.Files.AddFromTempFiles(document: FileStorageConst.EXPENSE_INCPECTION_FILE,
                                                                      tempFileIds: d.Files.Select(f => f.Id)
                                                                                          .ToList()));
            request.Insurances.AddTo(entity.Insurances, _mapper,
                                    (e, d) => e.Files.AddFromTempFiles(document: FileStorageConst.EXPENSE_INSURANCE_FILE,
                                                                       tempFileIds: d.Files.Select(f => f.Id)
                                                                                           .ToList()));
            request.Liquids.AddTo(entity.Liquids, _mapper,
                                    (e, d) => e.Files.AddFromTempFiles(document: FileStorageConst.EXPENSE_LIQUID_FILE,
                                                                       tempFileIds: d.Files.Select(f => f.Id)
                                                                                           .ToList()));
            request.Oils.AddTo(entity.Oils, _mapper,
                                    (e, d) => e.Files.AddFromTempFiles(document: FileStorageConst.EXPENSE_OIL_FILE,
                                                                       tempFileIds: d.Files.Select(f => f.Id)
                                                                                           .ToList()));
            request.Tires.AddTo(entity.Tires, _mapper,
                                    (e, d) => e.Files.AddFromTempFiles(document: FileStorageConst.EXPENSE_BATTERY_FILE,
                                                                       tempFileIds: d.Files.Select(f => f.Id)
                                                                                           .ToList()));
            #endregion

            // Attach files from temporary storage to the entity
            entity.Files.AddFromTempFiles(
                document: FileStorageConst.EXPENSE_FILE,
                tempFileIds: request.Files.Select(x => x.Id).ToList()
            );


            //Create and Save
            var result = await _context.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            // If there are files, move them from temporary storage to permanent storage
            if (request.Files.Any())
            {
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_FILE,
                    documentId: entity.Id.ToString(),
                    tempFileIds: request.Files.Select(x => x.Id).ToArray()
                );
            }

            await TableFileResolve(entity);

            // Create HistoryEntity and UploadMinio
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

            // Commit the transaction
            await transaction.CommitAsync(cancellationToken);

            // Return the ID of the newly created expense
            return HaveId.Create(entity.Id);
        }
        catch (Exception)
        {
            // Rollback the transaction in case of an error
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
    private async Task TableFileResolve(Expense entity)
    {
        foreach (var item in entity.Batteries)
        {
            if (item.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_BATTERY_FILE,
                    documentId: item.Id.ToString(),
                    tempFileIds: item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Inspections)
        {
            if (item.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_INCPECTION_FILE,
                    documentId: item.Id.ToString(),
                    tempFileIds: item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Insurances)
        {
            if (item.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_INSURANCE_FILE,
                    documentId: item.Id.ToString(),
                    tempFileIds: item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Oils)
        {
            if (item.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_OIL_FILE,
                    documentId: item.Id.ToString(),
                    tempFileIds: item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Liquids)
        {
            if (item.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_LIQUID_FILE,
                    documentId: item.Id.ToString(),
                    tempFileIds: item.Files.Select(x => x.Id).ToArray());
        }
        foreach (var item in entity.Tires)
        {
            if (item.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(
                    document: FileStorageConst.EXPENSE_TIRE_FILE,
                    documentId: item.Id.ToString(),
                    tempFileIds: item.Files.Select(x => x.Id).ToArray());
        }
    }
}

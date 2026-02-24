using AutoPark.Application.Security;
using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Refuels;

public class CreateRefuelCommandHandler :
    IRequestHandler<CreateRefuelCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public CreateRefuelCommandHandler(
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
    public async Task<IHaveId<long>> Handle(CreateRefuelCommand request,
                                      CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await ValidateCreateRefuelCommand(request, cancellationToken);
            //Create doc number automatically through number table
            var docNumberResult = _numberService.GetNext(NumberTamplateDocumentConst.REFUEL);

            // Create entity from request model
            var entity = request.CreateEntity<CreateRefuelCommand, Refuel>(_mapper);

            //Set doc number 
            entity.DocNumber = docNumberResult.docNumber;

            var userInfo = await _authService.GetUserAsync();
            if (!userInfo.Permissions.Contains(nameof(PermissionCode.ExpenseCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            if (!request.Latitude.HasValue || !request.Longitude.HasValue)
            {
                var presentTrackInfo = await _context.PresentTrackingInfos
                    .FirstOrDefaultAsync(pt => pt.Person.Drivers.Any(d => d.StateId == StateIdConst.ACTIVE && d.Id == request.DriverId), cancellationToken);


                if (presentTrackInfo != null)
                {
                    request.Latitude = presentTrackInfo.Latitude;
                    request.Longitude = presentTrackInfo.Longitude;
                }
            }

            //Status change and also creat event for writing history
            entity.Create();

            // Create entityFile in DB
            entity.Files.AddFromTempFiles(document: FileStorageConst.REFUEL_FILE,
                                          tempFileIds: request.Files.Select(x => x.Id).ToList());

            //Create and Save
            var result = await _context.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            // MoveToPersistent EntityFiles in Minio
            if (request.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.REFUEL_FILE,
                                                                 documentId: entity.Id.ToString(),
                                                                 tempFileIds: [.. request.Files.Select(x => x.Id)]);
            try
            {
                var entityById = await _mapper.MapCollection<Refuel, RefuelDto>(_context.Refuels)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                // Create HistoryEntity and UploadMinio
                var historyFileId = await _documentHistoryService.AddHistory<long, Refuel, RefuelDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.REFUEL_HISTORY,
                                                                         documentId: entity.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

    }

    private async Task ValidateCreateRefuelCommand(CreateRefuelCommand request,
                                                   CancellationToken cancellationToken)
    {
        var hasInfo = await _context.FuelCards
            .IsSoftActive()
            .AnyAsync(fc => !fc.IsDeleted &&
                            fc.Id == request.FuelCardId &&
                            fc.TransportId == request.TransportId);

        if (!hasInfo)
            throw ClientLogicalExceptionHelper.InvalidFuelCard(request.TransportId);
    }
}

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

namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingCommandHandler :
    IRequestHandler<CreateTransportSettingCommand, IHaveId<long>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IAsyncAppAuthService _appAuthService;

    public CreateTransportSettingCommandHandler(INumberService numberService,
                                                IWriteEfCoreContext context,
                                                IStorageAsyncService storageAsyncService,
                                                IDocumentHistoryService documentHistoryService,
                                                IMapProvider mapper,
                                                IAsyncAppAuthService appAuthService)
    {
        _documentHistoryService = documentHistoryService;
        _storageAsyncService = storageAsyncService;
        _numberService = numberService;
        _context = context;
        _mapper = mapper;
        _appAuthService = appAuthService;
    }

    public async Task<IHaveId<long>> Handle(
        CreateTransportSettingCommand request,
        CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Get next document number
            var docNumber = _numberService.GetNext(NumberTamplateDocumentConst.TRANSPORT_SETTING);


            // Create TransportSetting entity
            var entity = request.CreateEntity<CreateTransportSettingCommand, TransportSetting>(_mapper);

            // set document number and date
            entity.DocNumber = docNumber.docNumber;
            entity.DocDate = DateTime.UtcNow.Date;

            if (request.BranchId is null)
            {
                var user = await _appAuthService.GetUserAsync();

                var branch = await _context.Branches
                    .FirstOrDefaultAsync(r => r.Id == user.BranchId, cancellationToken);

                if (branch != null)
                {
                    entity.BranchId = branch.Id;
                }
            }

            entity.Create();

            // set document child entities
            request.Batteries.AddTo(entity.Batteries, _mapper);
            request.Fuels.AddTo(entity.Fuels, _mapper);
            request.Inspections.AddTo(entity.Inspections, _mapper);
            request.Insurances.AddTo(entity.Insurances, _mapper);
            request.Liquids.AddTo(entity.Liquids, _mapper);
            request.Oils.AddTo(entity.Oils, _mapper);
            request.Tires.AddTo(entity.Tires, _mapper);

            entity.Files.AddFromTempFiles(document: FileStorageConst.TRANSPORT_SETTING_FILE,
                                          tempFileIds: request.Files.Select(x => x.Id).ToList());

            // save entity
            var result = await _context.CreateAndSaveAsync<long, TransportSetting>(entity, cancellationToken);

            if (request.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.TRANSPORT_SETTING_FILE,
                                                                 documentId: entity.Id.ToString(),
                                                                 tempFileIds: request.Files.Select(x => x.Id).ToArray());
            // History part
            try
            {
                var entityById = await _mapper.MapCollection<TransportSetting, TransportSettingDto>(_context.TransportSettings)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                // Create HistoryEntity and UploadMinio
                var historyFileId = await _documentHistoryService.AddHistory<long, TransportSetting, TransportSettingDto>(entityById, cancellationToken);

                // Move files to persistent storage to Main storage
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.TRANSPORT_SETTING_HISTORY,
                                                                         documentId: entity.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            // transaction commit
            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(result);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

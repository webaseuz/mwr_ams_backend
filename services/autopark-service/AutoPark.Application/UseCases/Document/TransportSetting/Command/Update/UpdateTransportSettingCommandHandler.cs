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

namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingCommandHandler :
    IRequestHandler<UpdateTransportSettingCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IAsyncAppAuthService _appAuthService;

    public UpdateTransportSettingCommandHandler(
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService,
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService appAuthService)
    {
        _documentHistoryService = documentHistoryService;
        _storageAsyncService = storageAsyncService;
        _context = context;
        _mapper = mapper;
        _appAuthService = appAuthService;
    }
    public async Task<IHaveId<long>> Handle(UpdateTransportSettingCommand request,
                                            CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _context.TransportSettings
                .Include(x => x.Files)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            if (request.BranchId is null)
            {
                var user = await _appAuthService.GetUserAsync();

                var branch = await _context.Branches
                    .FirstOrDefaultAsync(r => r.Id == user.BranchId, cancellationToken);

                if (branch != null)
                {
                    request.BranchId = branch.Id;
                }
            }

            entity.Files.UpdateFromFiles(document: FileStorageConst.TRANSPORT_SETTING_FILE,
                                         documentId: entity.Id.ToString(),
                                         files: request.Files.Select(x => x.Id).ToList(),
                                         context: _context);

            request.UpdateEntity(entity, _mapper);
            request.Batteries.ApplyChangesTo<long, UpdateTransportSettingBatteryCommand, TransportSettingBattery>(entity.Batteries, _mapper);
            request.Fuels.ApplyChangesTo<long, UpdateTransportSettingFuelCommand, TransportSettingFuel>(entity.Fuels, _mapper);
            request.Inspections.ApplyChangesTo<long, UpdateTransportSettingInspectionCommand, TransportSettingInspection>(entity.Inspections, _mapper);
            request.Insurances.ApplyChangesTo<long, UpdateTransportSettingInsuranceCommand, TransportSettingInsurance>(entity.Insurances, _mapper);
            request.Liquids.ApplyChangesTo<long, UpdateTransportSettingLiquidCommand, TransportSettingLiquid>(entity.Liquids, _mapper);
            request.Oils.ApplyChangesTo<long, UpdateTransportSettingOilCommand, TransportSettingOil>(entity.Oils, _mapper);
            request.Tires.ApplyChangesTo<long, UpdateTransportSettingTireCommand, TransportSettingTire>(entity.Tires, _mapper);


            entity.Update();
            await _context.SaveChangesAsync(cancellationToken);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.TRANSPORT_SETTING_FILE,
                                                               documentId: request.Id.ToString());

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

            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(request.Id);

        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

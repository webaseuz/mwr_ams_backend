using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace AutoPark.Application.UseCases.TransportSettings;

public class DeleteTransportSettingCommandHandler :
    IRequestHandler<DeleteTransportSettingCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    public DeleteTransportSettingCommandHandler(IWriteEfCoreContext context,
                                                IStorageAsyncService storageAsyncService,
                                                IMapProvider mapper,
                                                IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }
    public async Task<SuccessResult<bool>> Handle(DeleteTransportSettingCommand request,
                                                  CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _context.TransportSettings
           .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            entity.Delete();
            await _context.SaveChangesAsync(cancellationToken);

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
            return SuccessResult.Create(true);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

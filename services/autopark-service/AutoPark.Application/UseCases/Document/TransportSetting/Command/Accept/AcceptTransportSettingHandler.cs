using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportSettings;

public class AcceptTransportSettingHandler :
    IRequestHandler<AcceptTransportSettingCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    public AcceptTransportSettingHandler(IWriteEfCoreContext context,
                                         IStorageAsyncService storageAsyncService,
                                         IMapProvider mapper,
                                         IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }
    public async Task<IHaveId<long>> Handle(AcceptTransportSettingCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var existDocument = await _context.TransportSettings.
                FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (existDocument is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            var existAcceptedDocument = await _context.TransportSettings
                .AsNoTracking()
                .Where(d => d.TransportId == existDocument.TransportId && d.StatusId == StatusIdConst.ACCEPTED)
                .Include(d => d.Transport)
                    .ThenInclude(t => t.TransportModel)
                .FirstOrDefaultAsync(cancellationToken);

            // exist accepted document
            if (existAcceptedDocument is not null)
            {
                var transportName = $"({existAcceptedDocument.Transport.StateCode}{existAcceptedDocument.Transport.StateCode} " +
                    $"({existAcceptedDocument.Transport.TransportModel.Translates.AsQueryable()
                    .FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name,
                    ServiceProvider.CultureHelper.CurrentCulture.Id))?.TranslateText ?? existAcceptedDocument.Transport.TransportModel.FullName}))";

                throw ClientLogicalExceptionHelper.AcceptDocumntAlreadyExists(transportName, existAcceptedDocument.DocNumber);
            }

            existDocument.Accept();

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<TransportSetting, TransportSettingDto>(_context.TransportSettings)
                    .FirstOrDefaultAsync(r => r.Id == existDocument.Id, cancellationToken);

                // Create HistoryEntity and UploadMinio
                var historyFileId = await _documentHistoryService.AddHistory<long, TransportSetting, TransportSettingDto>(entityById, cancellationToken);

                // Move files to persistent storage to Main storage
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.TRANSPORT_SETTING_HISTORY,
                                                                         documentId: existDocument.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            await transaction.CommitAsync(cancellationToken);
            return HaveId.Create(existDocument.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

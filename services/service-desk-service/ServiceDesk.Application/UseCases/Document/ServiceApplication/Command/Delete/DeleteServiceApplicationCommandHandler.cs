using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Domain.Constants;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class DeleteServiceApplicationCommandHandler :
    IRequestHandler<DeleteServiceApplicationCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public DeleteServiceApplicationCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }
    public async Task<SuccessResult<bool>> Handle(
        DeleteServiceApplicationCommand request, 
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await _context.ServiceApplications
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            entity.Delete();

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<ServiceApplication, ServiceApplicationDto>(_context.ServiceApplications)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, ServiceApplication, ServiceApplicationDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SERVICE_APPLICATION_HISTORY,
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

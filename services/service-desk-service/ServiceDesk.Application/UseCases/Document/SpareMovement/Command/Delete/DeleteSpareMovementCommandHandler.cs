using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using Bms.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class DeleteSpareMovementCommandHandler :
    IRequestHandler<DeleteSpareMovementCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public DeleteSpareMovementCommandHandler(
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

    public async Task<SuccessResult<bool>> Handle(
		DeleteSpareMovementCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
			var entity = await _context.SpareMovements
			.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity == null)
				throw ClientLogicalExceptionHelper.NotFound(request.Id);

			entity.Delete();

			await _context.SaveChangesAsync(cancellationToken);

			try
			{
				var entityById = await _mapper.MapCollection<SpareMovement, SpareMovementDto>(_context.SpareMovements)
					.FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

				var historyFileId = await _documentHistoryService.AddHistory<long, SpareMovement, SpareMovementDto>(entityById, cancellationToken);

				await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SPARE_MOVEMENT_HISTORY,
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

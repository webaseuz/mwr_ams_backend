using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using Microsoft.EntityFrameworkCore;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class UpdateSpareMovementCommandHandler :
    IRequestHandler<UpdateSpareMovementCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public UpdateSpareMovementCommandHandler(
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

    public async Task<IHaveId<long>> Handle(
		UpdateSpareMovementCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _context.SpareMovements
                .Include(x => x.Tables)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity == null)
				throw ClientLogicalExceptionHelper.NotFound(request.Id);

            request.Tables.ApplyChangesTo<long, UpdateSpareMovementTableCommand, SpareMovementTable>(entity.Tables, _mapper);
			entity.Update();

			request.UpdateEntity(entity, _mapper);
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

            return HaveId.Create(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

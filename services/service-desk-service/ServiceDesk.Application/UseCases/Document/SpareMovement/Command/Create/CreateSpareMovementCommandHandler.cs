using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class CreateSpareMovementCommandHandler :
    IRequestHandler<CreateSpareMovementCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly INumberService _numberService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public CreateSpareMovementCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        INumberService numberService,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _numberService = numberService;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
		CreateSpareMovementCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var docNumberResult = _numberService.GetNext(NumberTamplateDocumentConst.SPARE_MOVEMENT);

            var entity = request.CreateEntity<CreateSpareMovementCommand, SpareMovement>(_mapper);

            entity.DocNumber = docNumberResult.docNumber;

            entity.Create();

            request.Tables.AddTo(entity.Tables, _mapper);
            
            var result = await _context.AddAsync(entity, cancellationToken);
            
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
                await transaction.RollbackAsync(cancellationToken);
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

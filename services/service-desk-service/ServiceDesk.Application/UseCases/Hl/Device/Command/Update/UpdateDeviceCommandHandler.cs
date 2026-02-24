using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.Devices;

public class UpdateDeviceCommandHandler :
    IRequestHandler<UpdateDeviceCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;

    public UpdateDeviceCommandHandler(
        IStorageAsyncService storageAsyncService,
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(UpdateDeviceCommand request, 
                                     CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
			var entity = await _context.Devices
                .Include(x => x.Files)
			    .IsSoftActive()
			    .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

			if (entity == null)
				throw ClientLogicalExceptionHelper.NotFound(request.Id);

			entity.Files.UpdateFromFiles(document: FileStorageConst.DEVICE_FILE,
										 documentId: entity.Id.ToString(),
			                             files: request.Files.Select(x => x.Id).ToList(),
			                             context: _context);

			await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.DEVICE_FILE,
															   documentId: request.Id.ToString());

			request.UpdateEntity(entity, _mapper);

			await _context.SaveChangesAsync(cancellationToken);

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

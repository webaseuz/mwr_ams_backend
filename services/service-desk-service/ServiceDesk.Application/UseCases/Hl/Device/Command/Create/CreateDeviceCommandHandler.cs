using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using Bms.WEBASE.Storage;
using Bms.WEBASE.MinioSdk;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.Devices;

public class CreateDeviceCommandHandler :
    IRequestHandler<CreateDeviceCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;

    public CreateDeviceCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context,
        IStorageAsyncService storageAsyncService)
    {
        _mapper = mapper;
        _context = context;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<int>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = request.CreateEntity<CreateDeviceCommand, Device>(_mapper);

            entity.MarkAsActive();

            entity.Files.AddFromTempFiles(document: FileStorageConst.DEVICE_FILE,
                                              tempFileIds: request.Files.Select(x => x.Id).ToList());

            var result = await _context.CreateAndSaveAsync<int, Device>(entity, cancellationToken);

            if (request.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.DEVICE_FILE,
                                                                 documentId: entity.Id.ToString(),
                                                                 tempFileIds: request.Files.Select(x => x.Id).ToArray());

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

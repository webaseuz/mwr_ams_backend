using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class CreateMobileAppVersionCommandHandler :
    IRequestHandler<CreateMobileAppVersionCommand, IHaveId<Guid>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    public CreateMobileAppVersionCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
    }
    public async Task<IHaveId<Guid>> Handle(
        CreateMobileAppVersionCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var existEntity = await _context.MobileAppVersions.AnyAsync(x => x.VersionCode == request.VersionCode);
            if (existEntity)
                throw ClientLogicalExceptionHelper.AlreadyExists(request.VersionCode);
            
            var entity = request.CreateEntity<CreateMobileAppVersionCommand, MobileAppVersion>(_mapper);
            
            entity.MarkAsActive();

            var result = await _context.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.MOBILE_APP_VERSION,
                                                             documentId: entity.VersionCode,
                                                             tempFileIds: request.Id);

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

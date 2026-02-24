using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Persons;

public class UpdatePersonCommandHandler :
    IRequestHandler<UpdatePersonCommand, IHaveId<long>>

{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    public UpdatePersonCommandHandler(
        IWriteEfCoreContext context,
        IStorageAsyncService storageAsyncService,
        IMapProvider mapper)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<long>> Handle(
        UpdatePersonCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.People
           .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        if (request.FileId.HasValue && entity.FileId != request.FileId)
        {
            if (entity.FileId.HasValue)
                _storageAsyncService.MarkFileForDelete(FileStorageConst.PERSON_FILE,
                                                       entity.Id.ToString(),
                                                       entity.FileId.Value);

            _storageAsyncService.MarkFileForMoveToPersistent(FileStorageConst.PERSON_FILE,
                                                             entity.Id.ToString(),
                                                             request.FileId.Value);
        }

        request.UpdateEntity(entity, _mapper);

        await _context.SaveChangesAsync(cancellationToken);

        await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.PERSON_FILE,
                                                                   documentId: entity.Id.ToString());
        return HaveId.Create(request.Id);
    }
}
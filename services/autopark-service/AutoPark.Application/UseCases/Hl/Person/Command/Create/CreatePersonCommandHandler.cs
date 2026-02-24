using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Persons;

public class CreatePersonCommandHandler :
    IRequestHandler<CreatePersonCommand, IHaveId<long>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;

    public CreatePersonCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context,
        IStorageAsyncService storageAsyncService)
    {
        _mapper = mapper;
        _context = context;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<long>> Handle(
        CreatePersonCommand request,
        CancellationToken cancellationToken)
    {
        var existingPerson = _context.People
            .FirstOrDefaultAsync(p => p.Pinfl == request.Pinfl, cancellationToken);

        if (existingPerson != null)
        {
            throw ClientLogicalExceptionHelper.AlreadyExists(nameof(request.Pinfl));
        }

        if (request.Inn != null)
        {
            var existingPersonWithSameInn = _context.People
                .FirstOrDefaultAsync(p => p.Inn == request.Inn, cancellationToken);

            if (existingPersonWithSameInn != null)
            {
                throw ClientLogicalExceptionHelper.AlreadyExists(nameof(request.Inn));
            }
        }


        var entity = request.CreateEntity<CreatePersonCommand, Person>(_mapper);

        entity.SetFIO();
        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<long, Person>(entity, cancellationToken);

        if (request.FileId.HasValue)
            await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.PERSON_FILE,
                                                             documentId: entity.Id.ToString(),
                                                             tempFileIds: request.FileId.Value);

        return HaveId.Create(result);
    }
}

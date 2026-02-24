using AutoPark.Application.UseCases.Persons;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Drivers;

public class CreateDriverCommandHandler :
    IRequestHandler<CreateDriverCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;

    public CreateDriverCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context,
        IStorageAsyncService storageAsyncService)
    {
        _mapper = mapper;
        _context = context;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<int>> Handle(
        CreateDriverCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            if (request.Person.Inn.IsNullOrEmptyObject())
                request.Person.Inn = null;

            var personData = await _context.People
                .FirstOrDefaultAsync(p => p.Pinfl == request.Person.Pinfl, cancellationToken);

            if (personData is not null && await _context.Drivers.AnyAsync(x => x.PersonId == personData.Id && x.StateId == StateIdConst.ACTIVE))
                throw ClientLogicalExceptionHelper.AlreadyExists(nameof(request.Person));

            if (!request.Documents.Any(x => x.DocumentTypeId == DocumentTypeIdConst.DRIVER_LICENCE))
                throw new Exception("Haydovchilik guvohnomasi majburiy!");

            if (request.Documents.GroupBy(a => a.DocumentTypeId).Any(a => a.Count() > 1))
                throw new Exception("Har bir hujjat turi uchun maksimal 1 ta fayl qo'shish mumkin!");

            var person = new Person();

            var entity = request.CreateEntity<CreateDriverCommand, Driver>(_mapper);
            entity.UniqueCode = Guid.NewGuid();

            if (personData is null)
            {
                person = await CreatePersonAsync(request.Person, cancellationToken);
                entity.PersonId = person.Id;
            }
            else
            {
                entity.PersonId = personData.Id;
            }

            entity.MarkAsActive();

            var result = await _context.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);

            if (request.Documents.Any(x => x.DocumentFileId.HasValue))
            {
                var array = request.Documents.Where(x => x.DocumentFileId.HasValue).Select(x => x.DocumentFileId.Value).ToArray();
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.DRIVER_DOCUMENT_FILE,
                                                                    documentId: entity.Id.ToString(),
                                                                    tempFileIds: array);
            }
            await transaction.CommitAsync();

            return HaveId.Create(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task<Person> CreatePersonAsync(CreatePersonCommand personCommand,
                                                 CancellationToken cancellationToken)
    {
        var person = personCommand.CreateEntity<CreatePersonCommand, Person>(_mapper);

        person.SetFIO();
        person.MarkAsActive();

        await _context.People.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        if (personCommand.FileId.HasValue)
            await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.PERSON_FILE,
                                                             documentId: person.Id.ToString(),
                                                             tempFileIds: personCommand.FileId.Value);

        return person;
    }
}

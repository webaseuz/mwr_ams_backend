using AutoPark.Application.UseCases.Persons;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Users;

public class UpdateUserCommandHandler :
    IRequestHandler<UpdateUserCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;

    public UpdateUserCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Person.Inn.IsNullOrEmptyObject())
            request.Person.Inn = null;

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            //User Update
            var entity = await _context.Users.Include(x => x.UserRoles)
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);




            if (!string.IsNullOrEmpty(request.Password))
            {
                var (passwordHash, passwordSalt) = HashPassword(request.Password);
                entity.SetPassword(passwordHash, passwordSalt);
            }

            var person = await _context.People
                .FirstOrDefaultAsync(p => p.Id == entity.PersonId, cancellationToken);

            //request.Person.Id = entity.PersonId;

            PersonFile(request.Person, person);
            //Person Update
            request.Person.SetFIO();

            if (request.Person.Id == entity.Person.Id)
            {
                //person.Inn = request.Person.Inn;
                //person.Pinfl = request.Person.Pinfl;
                //person.DocumentNumber = request.Person.DocumentNumber;
                //person.DocumentTypeId = request.Person.DocumentTypeId;
                //person.DocumentSeria = request.Person.DocumentSeria;
                //person.FirstName = request.Person.FirstName;
                //person.LastName = request.Person.LastName;
                //person.MiddleName = request.Person.MiddleName;
                //person.SetFIO();
                //person.FileName = request.Person.FileName;
                //person.FileId = request.Person.FileId;
                //person.BirthCountryId = request.Person.BirthCountryId;
                //person.BirthRegionId = request.Person.BirthRegionId;
                //person.BirthDistrictId = request.Person.BirthDistrictId;
                //person.GenderId = request.Person.GenderId;
                //person.BirthOn = request.Person.BirthOn;
                //person.CitizenshipId = request.Person.CitizenshipId;
                //person.LivingDistrictId = request.Person.LivingDistrictId;
                //person.LivingRegionId = request.Person.LivingRegionId;
                //person.BranchId = request.Person.BranchId;
                request.Person.UpdateEntity(person, _mapper);
            }

            else
                entity.PersonId = request.Person.Id;

            request.UpdateEntity(entity, _mapper);
            entity.UserRoles.UpdateFromForeignKeys(request.Roles);



            await _context.SaveChangesAsync(cancellationToken);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.PERSON_FILE,
                                                               documentId: entity.PersonId.ToString());

            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(request.Id);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }


    private (string passwordHash, string passwordSalt) HashPassword(string password)
    {
        var salt = HashHelper.CreateRandomSalt();
        var hash = HashHelper.ComputeSaltedHash(password, salt);
        return (hash, salt);
    }

    private void PersonFile(UpdatePersonCommand request, Person entity)
    {
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
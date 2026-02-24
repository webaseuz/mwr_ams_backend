using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.Persons;
using ServiceDesk.Domain.Constants;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Users;

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
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<int>> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            //User Update
            var entity = await _context.Users.Include(x => x.UserRoles) 
                .IsSoftActive()
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            request.UpdateEntity(entity, _mapper);
            entity.UserRoles.UpdateFromForeignKeys(request.Roles);

            if (!string.IsNullOrEmpty(request.Password))
            {
                var (passwordHash, passwordSalt) = HashPassword(request.Password);
                entity.SetPassword(passwordHash, passwordSalt);
            }

            var person = await _context.People
                .FirstOrDefaultAsync(p => p.Id == entity.PersonId, cancellationToken);

            PersonFile(request.Person, person);
            //Person Update
            request.Person.UpdateEntity(person, _mapper);

            person.SetFIO();

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
}
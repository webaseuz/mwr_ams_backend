using AutoPark.Application.UseCases.Persons;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Security.Abstraction;

namespace AutoPark.Application.UseCases.Users;

public class CreateUserCommandHandler :
    IRequestHandler<CreateUserCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IEncryptionService _encryptionService;
    private readonly IStorageAsyncService _storageAsyncService;

    public CreateUserCommandHandler(
    IMapProvider mapper,
    IWriteEfCoreContext context,
    IEncryptionService encryptionService,
    IStorageAsyncService storageAsyncService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _encryptionService = encryptionService ?? throw new ArgumentNullException(nameof(encryptionService));
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var person = new Person();

            await Validate(request.UserName, cancellationToken);
            var (passwordHash, passwordSalt) = HashPassword(request.Password);
            var encryptedPassword = EncryptPassword(request.Password);

            var user = request.CreateEntity<CreateUserCommand, User>(_mapper);
            user.TemporaryInfo = encryptedPassword; // Encrypted password stored in TempInfo

            var personData = await _context.People
                .FirstOrDefaultAsync(p => p.Pinfl == request.Person.Pinfl, cancellationToken);

            if (personData is null)
            {
                person = await CreatePersonAsync(request.Person, cancellationToken);
                //person.BranchId = user.BranchId;
                user.PersonId = person.Id;
            }
            else
            {
                user.PersonId = personData.Id;
            }

            user.SetPassword(passwordHash, passwordSalt);
            user.MarkAsActive();
            user.UserRoles.AddFromForeignKeys(request.Roles);

            var result = await _context.CreateAndSaveAsync<int, User>(user, cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(result);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private async Task Validate(string userName,
        CancellationToken cancellationToken)
    {
        var userExists = await _context.Users
            .AnyAsync(u => u.UserName == userName &&
                           !u.IsDeleted, cancellationToken);

        if (userExists)
            throw ClientLogicalExceptionHelper.AlreadyExists(userName);
    }

    private (string passwordHash, string passwordSalt) HashPassword(string password)
    {
        var salt = HashHelper.CreateRandomSalt();
        var hash = HashHelper.ComputeSaltedHash(password, salt);
        return (hash, salt);
    }

    private string EncryptPassword(string password)
        => _encryptionService.Encrypt(password);

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

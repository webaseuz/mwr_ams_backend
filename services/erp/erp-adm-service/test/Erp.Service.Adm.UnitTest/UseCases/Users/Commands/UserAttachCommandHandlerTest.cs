//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Storage;
//using NSubstitute;
//using Erp.Core;
//using Erp.Core.Service.Application;
//using Erp.Core.Service.Domain;
//using Erp.Service.Adm.Application;
//using Erp.Service.Adm.Models;

//namespace Erp.Service.Adm.UnitTest;
//public class UserAttachCommandHandlerTests
//{
//    private readonly IApplicationDbContext _contextMock;
//    private readonly IIdentityProvider _identityProviderMock;
//    private readonly ITenantProvider _tenantProviderMock;
//    private readonly UserAttachCommandHandler _handler;
//    private readonly DbSet<Person> _personsDbSetMock;
//    private readonly DbSet<User> _usersDbSetMock;
//    private readonly IDbContextTransaction _transactionMock;

//    public UserAttachCommandHandlerTests()
//    {
//        // Setup mocks
//        _contextMock = Substitute.For<IApplicationDbContext>();
//        _identityProviderMock = Substitute.For<IIdentityProvider>();
//        _tenantProviderMock = Substitute.For<ITenantProvider>();

//        // Create DbSet mocks
//        _personsDbSetMock = Substitute.For<DbSet<Person>, IQueryable<Person>>();
//        _usersDbSetMock = Substitute.For<DbSet<User>, IQueryable<User>>();

//        // Setup database mock
//        var databaseMock = Substitute.For<DatabaseFacade>(Substitute.For<DbContext>());
//        _transactionMock = Substitute.For<IDbContextTransaction>();

//        // Setup context properties
//        _contextMock.Persons.Returns(_personsDbSetMock);
//        _contextMock.Users.Returns(_usersDbSetMock);
//        _contextMock.Database.Returns(databaseMock);
//        databaseMock.BeginTransaction().Returns(_transactionMock);

//        // Create handler
//        _handler = new UserAttachCommandHandler(
//            _contextMock,
//            _identityProviderMock,
//            _tenantProviderMock
//        );
//    }

//    [Fact]
//    public async Task Handle_WhenPersonNotFound_ThrowsException()
//    {
//        // Arrange
//        var command = new UserAttachCommand
//        {
//            PersonId = 123,
//            UserName = "testuser",
//            Password = "password123",
//            OrderCode = 1
//        };

//        _personsDbSetMock.FirstOrDefaultAsync(Arg.Any<Func<Person, bool>>(), Arg.Any<CancellationToken>())
//            .ReturnsNull();

//        // Act
//        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

//        // Assert
//        await act.Should().ThrowAsync<Exception>()
//            .WithMessage("Person not found");
//    }

//    [Fact]
//    public async Task Handle_WhenUsernameExists_ThrowsException()
//    {
//        // Arrange
//        var command = new UserAttachCommand
//        {
//            PersonId = 123,
//            UserName = "existing_user",
//            Password = "password123",
//            OrderCode = 1
//        };

//        var person = new Person { Id = 123 };

//        _personsDbSetMock.FirstOrDefaultAsync(Arg.Any<Func<Person, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(person));

//        _usersDbSetMock.AnyAsync(Arg.Any<Func<User, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(true));

//        // Act
//        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

//        // Assert
//        await act.Should().ThrowAsync<Exception>()
//            .WithMessage("Username already exists");
//    }

//    [Fact]
//    public async Task Handle_WhenSuccessful_ReturnsTrue()
//    {
//        // Arrange
//        var command = new UserAttachCommand
//        {
//            PersonId = 123,
//            UserName = "newuser",
//            Password = "password123",
//            OrderCode = 1
//        };

//        var person = new Person { Id = 123 };
//        const int tenantId = 42;

//        _personsDbSetMock.FirstOrDefaultAsync(Arg.Any<Func<Person, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(person));

//        _usersDbSetMock.AnyAsync(Arg.Any<Func<User, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(false));

//        _tenantProviderMock.GetTenantIdOrThrow().Returns(tenantId);

//        _identityProviderMock.CreateUserAsync(Arg.Any<User>(), Arg.Any<string>())
//            .Returns(Task.FromResult(true));

//        // Act
//        var result = await _handler.Handle(command, CancellationToken.None);

//        // Assert
//        result.Should().BeTrue();

//        // Verify user was added to context
//        await _contextMock.Received(1).Users.AddAsync(Arg.Is<User>(u =>
//            u.UserName == "newuser" &&
//            u.PersonId == 123 &&
//            u.OrderCode == 1 &&
//            u.TenantId == tenantId &&
//            u.LanguageId == LanguageIdConst.EN));

//        // Verify SaveChanges was called twice - once after adding to context, once after identity creation
//        await _contextMock.Received(2).SaveChangesAsync(Arg.Any<CancellationToken>());

//        // Verify transaction was committed
//        await _transactionMock.Received(1).CommitAsync(Arg.Any<CancellationToken>());
//    }

//    [Fact]
//    public async Task Handle_ShouldTrimAndLowercaseUsername()
//    {
//        // Arrange
//        var command = new UserAttachCommand
//        {
//            PersonId = 123,
//            UserName = "  NewUser  ",  // Note the spaces and uppercase
//            Password = "password123",
//            OrderCode = 1
//        };

//        var person = new Person { Id = 123 };

//        _personsDbSetMock.FirstOrDefaultAsync(Arg.Any<Func<Person, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(person));

//        _usersDbSetMock.AnyAsync(Arg.Any<Func<User, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(false));

//        _tenantProviderMock.GetTenantIdOrThrow().Returns(42);

//        _identityProviderMock.CreateUserAsync(Arg.Any<User>(), Arg.Any<string>())
//            .Returns(Task.FromResult(true));

//        // Act
//        await _handler.Handle(command, CancellationToken.None);

//        // Assert
//        await _contextMock.Users.Received(1).AddAsync(Arg.Is<User>(u =>
//            u.UserName == "newuser"));  // Verify username was trimmed and lowercased
//    }

//    [Fact]
//    public async Task Handle_WhenIdentityCreationFails_TransactionNotCommitted()
//    {
//        // Arrange
//        var command = new UserAttachCommand
//        {
//            PersonId = 123,
//            UserName = "newuser",
//            Password = "password123",
//            OrderCode = 1
//        };

//        var person = new Person { Id = 123 };

//        _personsDbSetMock.FirstOrDefaultAsync(Arg.Any<Func<Person, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(person));

//        _usersDbSetMock.AnyAsync(Arg.Any<Func<User, bool>>(), Arg.Any<CancellationToken>())
//            .Returns(Task.FromResult(false));

//        _tenantProviderMock.GetTenantIdOrThrow().Returns(42);

//        // Identity creation fails
//        _identityProviderMock.CreateUserAsync(Arg.Any<User>(), Arg.Any<string>())
//            .Returns(Task.FromResult(false));

//        // Act
//        var result = await _handler.Handle(command, CancellationToken.None);

//        // Assert
//        result.Should().BeTrue();  // Method still returns true regardless of identity creation result

//        // Verify transaction was not committed
//        await _transactionMock.DidNotReceive().CommitAsync(Arg.Any<CancellationToken>());
//    }
//}

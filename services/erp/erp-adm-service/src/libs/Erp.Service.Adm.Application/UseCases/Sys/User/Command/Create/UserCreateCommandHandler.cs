using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.AppError.Abstraction;
using WEBASE.EntityFramework.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UserCreateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<UserCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var userExists = await context.Users
            .AnyAsync(u => u.UserName == request.UserName && !u.IsDeleted, cancellationToken);

        if (userExists)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "USER_ALREADY_EXISTS",
                    ErrorMessage = localizationBuilder.For("USER_ALREADY_EXISTS").WithData(new { UserName = request.UserName }).ToString()
                });

        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var person = await context.People
            .FirstOrDefaultAsync(p => p.Pinfl == request.Person.Pinfl, cancellationToken);

        if (person is null)
        {
            person = new Person
            {
                FirstName = request.Person.FirstName,
                MiddleName = request.Person.MiddleName,
                LastName = request.Person.LastName,
                FullName = request.Person.FullName,
                ShortName = request.Person.ShortName,
                Pinfl = request.Person.Pinfl,
                DocumentSeria = request.Person.DocSeria ?? string.Empty,
                DocumentNumber = request.Person.DocNumber ?? string.Empty,
                DocumentTypeId = request.Person.DocumentTypeId,
                BirthOn = request.Person.BirthOn,
                GenderId = request.Person.GenderId,
                StateId = WbStateIdConst.ACTIVE,
            };
            context.People.Add(person);
            await context.SaveChangesAsync(cancellationToken);
        }

        var user = new User
        {
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            PersonId = person.Id,
            LanguageId = request.LanguageId,
            StateId = request.StateId > 0 ? request.StateId : WbStateIdConst.ACTIVE,
            PasswordHash = string.Empty,
            PasswordSalt = string.Empty,
        };

        foreach (var ur in request.UserRoles ?? [])
            user.UserRoles.Add(new UserRole { RoleId = ur.RoleId, StateId = WbStateIdConst.ACTIVE });

        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return new WbHaveId<int>(user.Id);
    }
}

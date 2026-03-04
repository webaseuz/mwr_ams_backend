using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WEBASE;
using WEBASE.AppError.Abstraction;
using WEBASE.EntityFramework.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UserUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<UserUpdateCommand, bool>
{
    public async Task<bool> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Users
            .Include(x => x.UserRoles)
            .Where(x => !x.IsDeleted)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "USER_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("USER_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.PhoneNumber = request.PhoneNumber;
        entity.LanguageId = request.LanguageId;
        entity.StateId = request.StateId;

        if (!string.IsNullOrEmpty(request.Password))
        {
            var (hash, salt) = HashPassword(request.Password);
            entity.PasswordHash = hash;
            entity.PasswordSalt = salt;
        }

        // Update UserRoles
        var newRoleIds = (request.UserRoles ?? []).Select(r => r.RoleId).ToHashSet();
        foreach (var ur in entity.UserRoles.Where(x => !x.IsDeleted).ToList())
        {
            if (!newRoleIds.Contains(ur.RoleId))
                ur.IsDeleted = true;
        }
        var existingRoleIds = entity.UserRoles.Where(x => !x.IsDeleted).Select(x => x.RoleId).ToHashSet();
        foreach (var ur in (request.UserRoles ?? []).Where(r => !existingRoleIds.Contains(r.RoleId)))
            entity.UserRoles.Add(new UserRole { RoleId = ur.RoleId, StateId = WbStateIdConst.ACTIVE });

        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static (string hash, string salt) HashPassword(string password)
    {
        var saltBytes = RandomNumberGenerator.GetBytes(32);
        var salt = Convert.ToBase64String(saltBytes);
        var combined = Encoding.UTF8.GetBytes(salt + password);
        var hashBytes = SHA256.HashData(combined);
        return (Convert.ToBase64String(hashBytes), salt);
    }
}

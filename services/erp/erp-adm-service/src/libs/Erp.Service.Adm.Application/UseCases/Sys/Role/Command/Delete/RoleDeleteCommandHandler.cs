using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.AppError.Abstraction;
using WEBASE.EntityFramework.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RoleDeleteCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RoleDeleteCommand, bool>
{
    public async Task<bool> Handle(RoleDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Roles
            .Where(x => !x.IsDeleted)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "ROLE_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("ROLE_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.StateId = WbStateIdConst.PASSIVE;
        entity.IsDeleted = true;

        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

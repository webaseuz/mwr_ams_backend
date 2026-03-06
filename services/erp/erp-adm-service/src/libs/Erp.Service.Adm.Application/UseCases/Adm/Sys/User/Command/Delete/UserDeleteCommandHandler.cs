using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UserDeleteCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<UserDeleteCommand, bool>
{
    public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Users
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

        entity.StateId = WbStateIdConst.PASSIVE;
        entity.IsDeleted = true;

        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

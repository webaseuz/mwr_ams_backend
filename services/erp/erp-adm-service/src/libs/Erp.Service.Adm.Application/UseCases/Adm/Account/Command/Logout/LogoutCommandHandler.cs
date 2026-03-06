using Erp.Core.Service.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class LogoutCommandHandler(
    IApplicationDbContext context,
    ITokenProvider tokenProvider) : IRequestHandler<LogoutCommand, bool>
{
    public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await context.UserTokens
            .Where(ut => ut.TokenHash == tokenProvider.TokenHash)
            .ExecuteUpdateAsync(
                a => a.SetProperty(a => a.IsDeleted, a => true), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

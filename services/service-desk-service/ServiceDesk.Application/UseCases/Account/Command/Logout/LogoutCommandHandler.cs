using Bms.WEBASE.Models;
using Bms.WEBASE.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application;

namespace ServiceDesk.Application.UseCases.Accounts;

public class LogoutCommandHandler :
    IRequestHandler<LogoutCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly ITokenProvider _tokenProvider;

    public LogoutCommandHandler(
        IWriteEfCoreContext context,
        ITokenProvider tokenProvider)
    {
        _context = context;
        _tokenProvider = tokenProvider;
    }

    public async Task<SuccessResult<bool>> Handle(LogoutCommand request,
                                                   CancellationToken cancellationToken)
    {
        //This approach do not load information into memory.It update database itself
        await _context.UserTokens
            .Where(ut => ut.TokenHash == _tokenProvider.TokenHash)
            .ExecuteUpdateAsync(
            a => a.SetProperty(a => a.IsDeleted, a => true), cancellationToken);


        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}

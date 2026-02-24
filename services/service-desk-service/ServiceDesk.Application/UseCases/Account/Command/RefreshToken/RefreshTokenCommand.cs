using MediatR;

namespace ServiceDesk.Application.UseCases.Accounts;

public class RefreshTokenCommand :
    IRequest<TokenResultDto>
{
    public string RefreshToken { get; set; }
}

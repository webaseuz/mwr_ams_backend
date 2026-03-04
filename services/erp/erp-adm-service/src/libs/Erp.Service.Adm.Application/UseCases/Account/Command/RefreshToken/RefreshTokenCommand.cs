using MediatR;

namespace AutoPark.Application.UseCases.Accounts;

public class RefreshTokenCommand :
    IRequest<TokenResultDto>
{
    public string RefreshToken { get; set; }
}

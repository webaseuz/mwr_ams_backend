using MediatR;

namespace AutoPark.Application.UseCases.Accounts;

public class GenerateTokenCommand :
    IRequest<UserTokenInfoDto>
{
    public string UserIdentity { get; set; }
    public string Password { get; set; }
}

using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class GenerateTokenCommand : IRequest<UserTokenInfoDto>
{
    public string UserIdentity { get; set; }
    public string Password { get; set; }
}

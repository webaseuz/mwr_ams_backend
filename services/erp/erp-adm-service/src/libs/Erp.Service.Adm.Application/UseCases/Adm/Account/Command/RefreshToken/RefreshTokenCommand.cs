using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class RefreshTokenCommand : IRequest<TokenResultDto>
{
    public string RefreshToken { get; set; }
}

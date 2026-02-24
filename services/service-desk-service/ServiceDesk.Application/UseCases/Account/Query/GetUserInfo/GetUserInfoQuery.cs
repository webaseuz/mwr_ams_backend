using MediatR;

namespace ServiceDesk.Application.UseCases.Accounts;

public class GetUserInfoQuery :
    IRequest<UserInfoDto>
{
}

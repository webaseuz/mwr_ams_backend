using MediatR;

namespace AutoPark.Application.UseCases.Accounts;

public class GetUserInfoQuery :
    IRequest<UserInfoDto>
{
}

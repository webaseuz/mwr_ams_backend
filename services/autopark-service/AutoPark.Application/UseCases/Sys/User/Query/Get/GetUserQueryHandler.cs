using AutoPark.Application.Users;
using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class GetUserQueryHandler :
    IRequestHandler<GetUserQuery, UserDto>
{
    public Task<UserDto> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new UserDto());
}

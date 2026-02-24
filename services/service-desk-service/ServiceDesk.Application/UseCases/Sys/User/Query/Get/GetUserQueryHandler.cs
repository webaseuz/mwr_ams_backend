using ServiceDesk.Application.Users;
using MediatR;

namespace ServiceDesk.Application.UseCases.Users;

public class GetUserQueryHandler :
    IRequestHandler<GetUserQuery, UserDto>
{
    public Task<UserDto> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new UserDto());
}

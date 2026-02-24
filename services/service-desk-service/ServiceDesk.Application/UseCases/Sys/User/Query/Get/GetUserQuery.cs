using ServiceDesk.Application.UseCases.Users;
using MediatR;

namespace ServiceDesk.Application.Users;

public class GetUserQuery :
    IRequest<UserDto>
{ }

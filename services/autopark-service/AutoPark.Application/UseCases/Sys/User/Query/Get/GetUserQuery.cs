using AutoPark.Application.UseCases.Users;
using MediatR;

namespace AutoPark.Application.Users;

public class GetUserQuery :
    IRequest<UserDto>
{ }

using MediatR;

namespace ServiceDesk.Application.UseCases.Users;

public class GetUserByIdQuery :
    IRequest<UserDto>
{
    public int Id { get; set; }
}

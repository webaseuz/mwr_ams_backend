using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class GetUserByIdQuery :
    IRequest<UserDto>
{
    public int Id { get; set; }
}

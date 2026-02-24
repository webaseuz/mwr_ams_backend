using MediatR;

namespace AutoPark.Application.UseCases.Roles;

public class GetRoleByIdQuery :
    IRequest<RoleDto>
{
    public int Id { get; set; }
}

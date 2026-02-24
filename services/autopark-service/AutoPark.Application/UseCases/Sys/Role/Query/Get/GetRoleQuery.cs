using MediatR;

namespace AutoPark.Application.UseCases.Roles;

public class GetRoleQuery :
    IRequest<RoleDto>
{
}

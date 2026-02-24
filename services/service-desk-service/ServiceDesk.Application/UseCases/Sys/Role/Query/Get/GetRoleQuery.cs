using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class GetRoleQuery :
	IRequest<RoleDto>
{
}

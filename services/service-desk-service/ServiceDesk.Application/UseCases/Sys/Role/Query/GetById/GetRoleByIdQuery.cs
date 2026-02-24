using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class GetRoleByIdQuery :
	IRequest<RoleDto>
{
	public int Id { get; set; }
}

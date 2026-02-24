using MediatR;

namespace ServiceDesk.Application.UseCases.Permissons;

public class GetPermissionSelectListQuery : 
	IRequest<IEnumerable<PermissionGroupSelectListDto>>
{
}

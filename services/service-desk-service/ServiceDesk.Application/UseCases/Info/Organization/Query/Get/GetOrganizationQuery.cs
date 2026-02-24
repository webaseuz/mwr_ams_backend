using MediatR;

namespace ServiceDesk.Application.UseCases.Organizations;

public class GetOrganizationQuery :
	IRequest<OrganizationDto>
{
}

using MediatR;

namespace ServiceDesk.Application.UseCases.Organizations;

public class GetOrganizationByIdQuery :
	IRequest<OrganizationDto>
{
	public int Id { get; set; }
}

using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class GetOrganizationQuery :
    IRequest<OrganizationDto>
{
}

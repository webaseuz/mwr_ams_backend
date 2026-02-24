using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class GetOrganizationByIdQuery :
    IRequest<OrganizationDto>
{
    public int Id { get; set; }
}

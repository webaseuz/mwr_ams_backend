using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class GetOrganizationQueryHandler :
    IRequestHandler<GetOrganizationQuery, OrganizationDto>
{
    public Task<OrganizationDto> Handle(
        GetOrganizationQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new OrganizationDto());
}

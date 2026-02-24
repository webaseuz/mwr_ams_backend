using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeQueryHandler :
    IRequestHandler<GetServiceTypeQuery, ServiceTypeDto>
{
    public Task<ServiceTypeDto> Handle(
		GetServiceTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new ServiceTypeDto());
}

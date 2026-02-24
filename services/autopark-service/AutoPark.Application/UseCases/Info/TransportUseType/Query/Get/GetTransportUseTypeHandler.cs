using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeHandler :
    IRequestHandler<GetTransportUseTypeQuery, TransportUseTypeDto>
{
    public Task<TransportUseTypeDto> Handle(
        GetTransportUseTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TransportUseTypeDto());
}

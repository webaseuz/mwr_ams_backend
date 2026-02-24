using MediatR;

namespace AutoPark.Application.UseCases.TransportTypes;

public class GetTransportTypeHandler :
    IRequestHandler<GetTransportTypeQuery, TransportTypeDto>
{
    public Task<TransportTypeDto> Handle(
        GetTransportTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TransportTypeDto());
}

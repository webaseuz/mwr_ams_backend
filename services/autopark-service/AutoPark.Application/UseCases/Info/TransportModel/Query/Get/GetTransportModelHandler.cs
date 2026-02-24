using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelHandler :
    IRequestHandler<GetTransportModelQuery, TransportModelDto>
{
    public Task<TransportModelDto> Handle(
        GetTransportModelQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TransportModelDto());
}

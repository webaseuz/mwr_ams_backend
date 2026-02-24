using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorHandler :
    IRequestHandler<GetTransportColorQuery, TransportColorDto>
{
    public Task<TransportColorDto> Handle(
        GetTransportColorQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TransportColorDto());
}

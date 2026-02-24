using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandHandler :
    IRequestHandler<GetTransportBrandQuery, TransportBrandDto>
{
    public Task<TransportBrandDto> Handle(
        GetTransportBrandQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TransportBrandDto());
}

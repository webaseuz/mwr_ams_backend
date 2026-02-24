using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandQuery :
    IRequest<TransportBrandDto>
{
}

using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandByIdQuery :
    IRequest<TransportBrandDto>
{
    public int Id { get; set; }
}

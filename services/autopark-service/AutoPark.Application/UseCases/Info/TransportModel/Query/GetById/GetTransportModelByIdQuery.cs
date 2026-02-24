using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelByIdQuery :
    IRequest<TransportModelDto>
{
    public int Id { get; set; }
}

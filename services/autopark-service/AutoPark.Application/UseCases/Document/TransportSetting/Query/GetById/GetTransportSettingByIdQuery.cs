using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class GetTransportSettingByIdQuery :
    IRequest<TransportSettingDto>
{
    public int Id { get; set; }
}
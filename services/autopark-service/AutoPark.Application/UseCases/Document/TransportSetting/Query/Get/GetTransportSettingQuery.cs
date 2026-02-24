using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class GetTransportSettingQuery :
    IRequest<TransportSettingDto>
{ }

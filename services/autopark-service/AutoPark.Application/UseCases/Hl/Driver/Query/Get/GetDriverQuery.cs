using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverQuery :
    IRequest<DriverDto>
{
}

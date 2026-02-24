using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverByIdQuery :
    IRequest<DriverDto>
{
    public int Id { get; set; }
}

using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverDocumentByIdQuery :
    IRequest<DriverDto>
{
    public int Id { get; set; }
}

using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeByIdQuery :
    IRequest<ServiceTypeDto>
{
    public int Id { get; set; }
}

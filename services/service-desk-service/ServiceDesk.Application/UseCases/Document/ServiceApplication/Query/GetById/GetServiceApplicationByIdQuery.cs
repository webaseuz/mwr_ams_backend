using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationByIdQuery :
    IRequest<ServiceApplicationDto>
{
    public long Id { get; set; }
}

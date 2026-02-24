using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationQuery :
    IRequest<ServiceApplicationDto>
{ }
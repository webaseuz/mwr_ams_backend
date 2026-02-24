using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeQuery :
    IRequest<ServiceTypeDto>
{ }

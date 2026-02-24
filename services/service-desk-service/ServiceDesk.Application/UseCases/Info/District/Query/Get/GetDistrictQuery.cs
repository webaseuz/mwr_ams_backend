using MediatR;

namespace ServiceDesk.Application.UseCases.Districts;

public class GetDistrictQuery :
    IRequest<DistrictDto>
{ }

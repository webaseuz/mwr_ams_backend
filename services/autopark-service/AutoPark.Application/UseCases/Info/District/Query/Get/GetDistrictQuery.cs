using MediatR;

namespace AutoPark.Application.UseCases.Districts;

public class GetDistrictQuery :
    IRequest<DistrictDto>
{ }

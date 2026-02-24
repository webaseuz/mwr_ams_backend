using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeQuery :
    IRequest<OilTypeDto>
{
}

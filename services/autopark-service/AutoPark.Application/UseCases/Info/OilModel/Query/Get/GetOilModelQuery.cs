using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelQuery :
    IRequest<OilModelDto>
{
}

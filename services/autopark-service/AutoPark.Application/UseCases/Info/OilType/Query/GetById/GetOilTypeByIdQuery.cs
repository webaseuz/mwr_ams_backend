using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeByIdQuery :
    IRequest<OilTypeDto>
{
    public int Id { get; set; }
}

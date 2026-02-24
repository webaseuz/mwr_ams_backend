using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelByIdQuery :
    IRequest<OilModelDto>
{
    public int Id { get; set; }
}

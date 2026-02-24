using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelByIdQuery :
    IRequest<TireModelDto>
{
    public int Id { get; set; }
}

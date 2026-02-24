using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class GetTireSizeByIdQuery :
    IRequest<TireSizeDto>
{
    public int Id { get; set; }
}

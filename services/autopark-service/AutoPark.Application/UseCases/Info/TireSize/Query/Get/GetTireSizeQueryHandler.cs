using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class GetTireSizeQueryHandler :
    IRequestHandler<GetTireSizeQuery, TireSizeDto>
{
    public Task<TireSizeDto> Handle(
        GetTireSizeQuery request,
        CancellationToken cancellationToken)
         => Task.FromResult(new TireSizeDto());

}

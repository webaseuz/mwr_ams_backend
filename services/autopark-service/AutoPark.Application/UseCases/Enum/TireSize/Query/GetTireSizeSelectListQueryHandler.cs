using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class GetTireSizeSelectListQueryHandler :
    IRequestHandler<GetTireSizeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTireSizeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTireSizeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.TireSizes
                    .AsSelectList(cancellationToken);
}

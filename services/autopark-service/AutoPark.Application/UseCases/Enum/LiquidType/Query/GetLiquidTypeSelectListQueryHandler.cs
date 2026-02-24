using AutoPark.Application.UseCases.Enums;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum;

public class GetLiquidTypeSelectListQueryHandler :
      IRequestHandler<GetLiquidTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetLiquidTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetLiquidTypeSelectListQuery reques,
                                                    CancellationToken cancellationToken)
       => await _context.LiquidTypes
        .AsSelectList(cancellationToken);
}

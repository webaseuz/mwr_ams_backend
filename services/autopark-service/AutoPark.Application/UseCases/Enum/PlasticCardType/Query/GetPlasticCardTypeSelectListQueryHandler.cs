using AutoPark.Application.UseCases.Enum.PlasticCardTypes;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.PlasticCardTypes;

public class GetPlasticCardTypeSelectListQueryHandler :
    IRequestHandler<GetPlasticCardTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetPlasticCardTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetPlasticCardTypeSelectListQuery request,
                                             CancellationToken cancellationToken)
            => await _context.PlasticCardTypes.
                    AsSelectList(cancellationToken);
}

using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Countries;

public class GetCountryTypeSelectListQueryHandler :
    IRequestHandler<GetCountryTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetCountryTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetCountryTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Countries
                .IsSoftActive()
                .AsSelectList(cancellationToken);
}

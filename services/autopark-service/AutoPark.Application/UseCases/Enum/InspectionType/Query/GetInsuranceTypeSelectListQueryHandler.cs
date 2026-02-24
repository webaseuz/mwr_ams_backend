using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInspectionTypeSelectListQueryHandler :
    IRequestHandler<GetInspectionTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetInspectionTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetInspectionTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.InspectionTypes
                .AsSelectList(cancellationToken);
}
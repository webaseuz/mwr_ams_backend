using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeSelectListQueryHandler :
    IRequestHandler<GetInsuranceTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetInsuranceTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetInsuranceTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.InsuranceTypes
                .AsSelectList(cancellationToken);
}
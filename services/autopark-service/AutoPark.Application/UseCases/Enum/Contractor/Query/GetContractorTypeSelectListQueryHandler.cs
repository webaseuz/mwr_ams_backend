using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Contractors;

public class GetContractorTypeSelectListQueryHandler :
    IRequestHandler<GetContractorTypeSelectListQuery, SelectList<long>>
{
    private readonly IReadEfCoreContext _context;

    public GetContractorTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<long>> Handle(GetContractorTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Contractors
                .IsSoftActive()
                .AsSelectList(cancellationToken);
}

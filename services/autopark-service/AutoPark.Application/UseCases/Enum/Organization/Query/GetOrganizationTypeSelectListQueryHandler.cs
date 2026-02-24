using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class GetOrganizationTypeSelectListQueryHandler :
    IRequestHandler<GetOrganizationTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetOrganizationTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetOrganizationTypeSelectListQuery request,
                                              CancellationToken cancellationToken)
        => await _context.Organizations
                .AsSelectList(cancellationToken);
}

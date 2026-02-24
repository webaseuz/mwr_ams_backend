using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankSelectListQueryHandler :
    IRequestHandler<GetBankSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetBankSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetBankSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Banks
                    .IsSoftActive()
                    .AsSelectList(cancellationToken);
}

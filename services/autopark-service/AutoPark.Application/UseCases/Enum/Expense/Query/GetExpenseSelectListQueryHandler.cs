using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseSelectListQueryHandler :
    IRequestHandler<GetExpenseSelectListQuery, SelectList<long>>
{
    private readonly IReadEfCoreContext _context;

    public GetExpenseSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<long>> Handle(GetExpenseSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Expenses
                .AsSelectList(cancellationToken);
}

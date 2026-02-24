using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ExecutorTypes;

public class GetExecutorTypeSelectListQueryHandler :
    IRequestHandler<GetExecutorTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetExecutorTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetExecutorTypeSelectListQuery request, 
                                        CancellationToken cancellationToken)
        => await _context.ExecutorTypes
					.AsSelectList(cancellationToken);
}

using ServiceDesk.Application.UseCases.Enum.Genders;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Genders;

public class GetGenderSelectListQueryHandler :
    IRequestHandler<GetGenderSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetGenderSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetGenderSelectListQuery request,
                                             CancellationToken cancellationToken)
            => await _context.Genders
                .AsSelectList(cancellationToken);
}

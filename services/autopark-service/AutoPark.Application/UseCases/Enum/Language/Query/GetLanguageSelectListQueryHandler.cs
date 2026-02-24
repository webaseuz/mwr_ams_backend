using AutoPark.Application.UseCases.Enums;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Languages;

public class GetLanguageSelectListQueryHandler :
    IRequestHandler<GetLanguageSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetLanguageSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetLanguageSelectListQuery reques,
                                                    CancellationToken cancellationToken)
       => await _context.Languages
        .AsSelectList(cancellationToken);
}

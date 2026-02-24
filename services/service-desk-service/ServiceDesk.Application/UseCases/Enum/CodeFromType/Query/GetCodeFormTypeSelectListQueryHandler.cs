using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.UseCases.Enum.CodeFromTypes;

namespace ServiceDesk.Application.UseCases.CodeFromTypes;

public class GetCodeFromTypeBriefListQueryHandler :
    IRequestHandler<GetCodeFromTypeBriefListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private IMapProvider _mapper;

    public GetCodeFromTypeBriefListQueryHandler(IReadEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SelectList<int>> Handle(GetCodeFromTypeBriefListQuery reques,
                                                    CancellationToken cancellationToken)
        => await _context.CodeFormTypes
            .AsSelectList(cancellationToken);
}

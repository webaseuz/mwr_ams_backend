using AutoPark.Application.UseCases.Enum.CodeFromTypes;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.CodeFromTypes;

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
            .IsSoftActive()
            .AsSelectList(cancellationToken);
}

using AutoPark.Application.UseCases.Enum.DocumentTypes;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.DocumentTypes;

public class GetDocumentTypeSelectListQueryHandler :
    IRequestHandler<GetDocumentTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private IMapProvider _mapper;

    public GetDocumentTypeSelectListQueryHandler(IReadEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SelectList<int>> Handle(GetDocumentTypeSelectListQuery reques,
                                                    CancellationToken cancellationToken)
            => await _context.DocumentTypes
                .IsSoftActive()
                .AsSelectList(cancellationToken);
}

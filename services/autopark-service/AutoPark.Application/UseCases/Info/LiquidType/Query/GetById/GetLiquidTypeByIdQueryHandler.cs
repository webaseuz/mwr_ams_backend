using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeByIdQueryHandler :
     IRequestHandler<GetLiquidTypeByIdQuery, LiquidTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetLiquidTypeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<LiquidTypeDto> Handle(
        GetLiquidTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.LiquidTypes
            .Where(a => a.StateId == StateIdConst.ACTIVE)
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<LiquidType, LiquidTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

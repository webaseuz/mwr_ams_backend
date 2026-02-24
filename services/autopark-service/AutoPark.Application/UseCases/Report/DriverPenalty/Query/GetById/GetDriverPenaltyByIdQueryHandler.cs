using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.DriverPenalties;

public class GetDriverPenaltyByIdQueryHandler
    : IRequestHandler<GetDriverPenaltyByIdQuery, DriverPenaltyDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetDriverPenaltyByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DriverPenaltyDto> Handle(GetDriverPenaltyByIdQuery request,
                                         CancellationToken cancellationToken)
    {
        var query = _context.DriverPenalties
            .Where(dp => dp.Id == request.Id);

        var result = await _mapper.MapCollection<DriverPenalty, DriverPenaltyDto>(query)
            .FirstOrDefaultAsync();

        if (result == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return result;
    }
}

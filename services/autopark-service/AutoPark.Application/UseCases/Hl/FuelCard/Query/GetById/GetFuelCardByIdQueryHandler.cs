using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardByIdQueryHandler :
    IRequestHandler<GetFuelCardByIdQuery, FuelCardDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetFuelCardByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FuelCardDto> Handle(
        GetFuelCardByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.FuelCards
            .IsSoftActive()
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<FuelCard, FuelCardDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

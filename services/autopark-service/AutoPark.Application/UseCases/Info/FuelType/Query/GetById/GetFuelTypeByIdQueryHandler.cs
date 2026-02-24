using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeByIdQueryHandler :
    IRequestHandler<GetFuelTypeByIdQuery, FuelTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetFuelTypeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FuelTypeDto> Handle(GetFuelTypeByIdQuery request,
                                    CancellationToken cancellationToken)
    {
        var query = _context.FuelTypes
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<FuelType, FuelTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

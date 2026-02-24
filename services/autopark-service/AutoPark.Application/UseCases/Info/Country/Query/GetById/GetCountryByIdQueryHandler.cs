using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Countries;

public class GetCountryByIdQueryHandler :
    IRequestHandler<GetCountryByIdQuery, CountryDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetCountryByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CountryDto> Handle(
        GetCountryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Countries
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Country, CountryDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

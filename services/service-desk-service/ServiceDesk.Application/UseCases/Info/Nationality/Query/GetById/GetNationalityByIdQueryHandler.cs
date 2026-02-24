using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class GetNationalityByIdQueryHandler :
    IRequestHandler<GetNationalityByIdQuery, NationalityDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetNationalityByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<NationalityDto> Handle(
        GetNationalityByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.Nationalities
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Nationality, NationalityDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

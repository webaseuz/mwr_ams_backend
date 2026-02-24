using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonByPinflQueryHandler :
    IRequestHandler<GetPersonByPinflQuery, PersonDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetPersonByPinflQueryHandler(IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonDto> Handle(
        GetPersonByPinflQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.People
            .Where(b => b.Pinfl == request.Pinfl);

        var dto = await _mapper.MapCollection<Person, PersonDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFoundPinfl(request.Pinfl);

        return dto;
    }
}

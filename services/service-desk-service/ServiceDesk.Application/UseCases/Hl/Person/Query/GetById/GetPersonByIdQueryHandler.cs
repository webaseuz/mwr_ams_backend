using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonByIdQueryHandler :
    IRequestHandler<GetPersonByIdQuery, PersonDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetPersonByIdQueryHandler(IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonDto> Handle(
        GetPersonByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.People
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Person, PersonDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
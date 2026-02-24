using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Application;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipByIdQueryHandler :
    IRequestHandler<GetCitizenshipByIdQuery, CitizenshipDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetCitizenshipByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CitizenshipDto> Handle(GetCitizenshipByIdQuery request,
                                      CancellationToken cancellationToken)
    {
        var query = _context.Citizenships
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Citizenship, CitizenshipDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
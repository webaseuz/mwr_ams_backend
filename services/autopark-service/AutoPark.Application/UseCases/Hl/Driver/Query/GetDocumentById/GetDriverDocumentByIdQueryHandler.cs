using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Drivers;

class GetDriverDocumentByIdQueryHandler :
    IRequestHandler<GetDriverDocumentByIdQuery, DriverDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetDriverDocumentByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DriverDto> Handle(
        GetDriverDocumentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Drivers
            .IsSoftActive()
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<Driver, DriverDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        return dto;
    }
}

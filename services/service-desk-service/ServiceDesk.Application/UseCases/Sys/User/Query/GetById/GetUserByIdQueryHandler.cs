using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Users;

public class GetUserByIdQueryHandler :
    IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetUserByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(
        GetUserByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.Users
            .IsSoftActive()
            .Include(u => u.Person)
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<User, UserDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

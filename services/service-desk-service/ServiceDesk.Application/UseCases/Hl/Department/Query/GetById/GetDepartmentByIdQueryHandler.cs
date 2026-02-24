using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

public class GetDepartmentByIdQueryHandler :
    IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetDepartmentByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DepartmentDto> Handle(
        GetDepartmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Departments
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Department, DepartmentDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

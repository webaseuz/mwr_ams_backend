using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class GetApplicationPurposeByIdQueryHandler : IRequestHandler<GetApplicationPurposeByIdQuery, ApplicationPurposeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetApplicationPurposeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApplicationPurposeDto> Handle(
        GetApplicationPurposeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.ApplicationPurposes
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<ApplicationPurpose, ApplicationPurposeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
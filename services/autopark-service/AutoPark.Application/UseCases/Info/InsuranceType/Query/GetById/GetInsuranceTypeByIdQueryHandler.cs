using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeByIdQueryHandler :
    IRequestHandler<GetInsuranceTypeByIdQuery, InsuranceTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetInsuranceTypeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<InsuranceTypeDto> Handle(GetInsuranceTypeByIdQuery request,
                                    CancellationToken cancellationToken)
    {
        var query = _context.InsuranceTypes
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<InsuranceType, InsuranceTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}

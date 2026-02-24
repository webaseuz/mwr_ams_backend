using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankByIdQueryHandler :
    IRequestHandler<GetBankByIdQuery, BankDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetBankByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BankDto> Handle(GetBankByIdQuery request,
                                      CancellationToken cancellationToken)
    {
        var query = _context.Banks
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Bank, BankDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransmissionBoxTypes;

public class GetTransmissionBoxTypeSelectListQueryHandler :
    IRequestHandler<GetTransmissionBoxTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetTransmissionBoxTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetTransmissionBoxTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.TransmissionBoxTypes
                    .IsSoftActive()
                    .AsSelectList(request, cancellationToken);
}

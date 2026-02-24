using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonSelectListQueryHandler :
    IRequestHandler<GetPersonSelectListQuery, SelectList<long>>
{
    private readonly IReadEfCoreContext _context;

    public GetPersonSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<long>> Handle(GetPersonSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.People
                    .IsSoftActive()
                    .AsSelectList(cancellationToken);
}

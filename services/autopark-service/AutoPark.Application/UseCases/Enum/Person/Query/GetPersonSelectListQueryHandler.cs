using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonSelectListQueryHandler :
    IRequestHandler<GetPersonSelectListQuery, SelectList<long>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetPersonSelectListQueryHandler(IReadEfCoreContext context, IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _appAuthService = appAuthService;
    }

    public async Task<SelectList<long>> Handle(GetPersonSelectListQuery request,
                                        CancellationToken cancellationToken)
       => await _context.People
                    .IsSoftActive()
                    .AsSelectList(request, _appAuthService, _context, cancellationToken);
}

using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonBriefPagedResultHandler :
    IRequestHandler<GetPersonBriefPagedResultQuery, PagedResultWithActionControls<PersonPriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _appAuthService;


    public GetPersonBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _mapper = mapper;
        _appAuthService = appAuthService;
    }

    public async Task<PagedResultWithActionControls<PersonPriefDto>> Handle(
        GetPersonBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Person, PersonPriefDto>(_context.People);

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _appAuthService.HasPermissionAsync(PermissionCode.PersonCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);
    }
}

using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Nationalities;

public class GetNationalityBriefPagedResultQueryHandler :
    IRequestHandler<GetNationalityBriefPagedResultQuery, PagedResultWithActionControls<NationalityBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetNationalityBriefPagedResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<NationalityBriefDto>> Handle(
        GetNationalityBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Nationality, NationalityBriefDto>(_context.Nationalities.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.NationalityCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
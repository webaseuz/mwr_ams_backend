using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankBriefPagedResultHandler :
    IRequestHandler<GetBankBriefPagedResultQuery, PagedResultWithActionControls<BankBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetBankBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<BankBriefDto>> Handle(
        GetBankBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Bank, BankBriefDto>(_context.Banks.IsSoftActive());

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.BankCreate)
        };

        query = query.SortFilter(request);

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
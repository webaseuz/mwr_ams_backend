using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPositionBriefPagedResultHandler : IRequestHandler<PositionGetListQuery, WbPagedResult<PositionBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public GetPositionBriefPagedResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async Task<WbPagedResult<PositionBriefDto>> Handle(PositionGetListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Positions
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<PositionBriefDto>(_mapper, _cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(a => a.ShortName.ToLower().Contains(search) ||
                                     a.FullName.ToLower().Contains(search) ||
                                     a.Code.Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

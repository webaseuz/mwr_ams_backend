using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetBranchBriefPagedResultHandler : IRequestHandler<BranchGetListQuery, WbPagedResult<BranchBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public GetBranchBriefPagedResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async Task<WbPagedResult<BranchBriefDto>> Handle(BranchGetListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Branches
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<BranchBriefDto>(_mapper, _cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(a => a.ShortName.ToLower().Contains(search) ||
                                     a.FullName.ToLower().Contains(search) ||
                                     a.UniqueCode.Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

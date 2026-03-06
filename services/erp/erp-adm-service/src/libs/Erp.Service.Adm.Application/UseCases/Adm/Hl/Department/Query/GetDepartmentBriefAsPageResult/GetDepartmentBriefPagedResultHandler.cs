using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDepartmentBriefPagedResultHandler : IRequestHandler<DepartmentGetListQuery, WbPagedResult<DepartmentBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public GetDepartmentBriefPagedResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async Task<WbPagedResult<DepartmentBriefDto>> Handle(DepartmentGetListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Departments
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<DepartmentBriefDto>(_mapper, _cultureHelper);

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

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

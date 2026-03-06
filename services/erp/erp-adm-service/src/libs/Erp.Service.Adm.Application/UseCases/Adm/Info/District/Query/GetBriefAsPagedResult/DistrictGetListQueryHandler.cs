using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DistrictGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<DistrictGetListQuery, WbPagedResult<DistrictBriefDto>>
{
    public async Task<WbPagedResult<DistrictBriefDto>> Handle(DistrictGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Districts
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<DistrictBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

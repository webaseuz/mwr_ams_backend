using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class MobileAppVersionGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<MobileAppVersionGetListQuery, WbPagedResult<MobileAppVersionBriefDto>>
{
    public async Task<WbPagedResult<MobileAppVersionBriefDto>> Handle(MobileAppVersionGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.MobileAppVersions
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<MobileAppVersionBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.FileName.ToLower().Contains(search) ||
                                     x.VersionCode.ToLower().Contains(search) ||
                                     x.Details.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

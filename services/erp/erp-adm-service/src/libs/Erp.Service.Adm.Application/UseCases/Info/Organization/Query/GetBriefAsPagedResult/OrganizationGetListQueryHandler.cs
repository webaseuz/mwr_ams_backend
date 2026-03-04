using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class OrganizationGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<OrganizationGetListQuery, WbPagedResult<OrganizationBriefDto>>
{
    public async Task<WbPagedResult<OrganizationBriefDto>> Handle(OrganizationGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Organizations
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<OrganizationBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

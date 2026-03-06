using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RoleGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<RoleGetListQuery, WbPagedResult<RoleBriefDto>>
{
    public async Task<WbPagedResult<RoleBriefDto>> Handle(RoleGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Roles
            .Where(x => !x.IsDeleted)
            .MapTo<RoleBriefDto>(mapper, cultureHelper);

        if (request.StateId.HasValue)
            query = query.Where(x => x.StateId == request.StateId);

        if (request.HasSearch())
            query = query.Where(x => x.ShortName.ToLower().Contains(request.Search!.ToLower()) ||
                                     x.FullName.ToLower().Contains(request.Search!.ToLower()));

        return await query.AsPagedResultAsync(request);
    }
}

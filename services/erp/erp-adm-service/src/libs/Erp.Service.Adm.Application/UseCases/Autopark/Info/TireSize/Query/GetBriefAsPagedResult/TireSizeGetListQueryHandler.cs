using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TireSizeGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<TireSizeGetListQuery, WbPagedResult<TireSizeBriefDto>>
{
    public async Task<WbPagedResult<TireSizeBriefDto>> Handle(TireSizeGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.TireSizes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<TireSizeBriefDto>(mapper, cultureHelper);

        return await query.AsPagedResultAsync(request);
    }
}

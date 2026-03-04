using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class LiquidTypeGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<LiquidTypeGetListQuery, WbPagedResult<LiquidTypeBriefDto>>
{
    public async Task<WbPagedResult<LiquidTypeBriefDto>> Handle(LiquidTypeGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.LiquidTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<LiquidTypeBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

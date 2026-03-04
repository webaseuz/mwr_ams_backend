using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CurrencyGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<CurrencyGetListQuery, WbPagedResult<CurrencyBriefDto>>
{
    public async Task<WbPagedResult<CurrencyBriefDto>> Handle(CurrencyGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Currencies
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<CurrencyBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search) ||
                                     x.Code.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

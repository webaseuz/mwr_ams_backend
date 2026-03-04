using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportTypeGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<TransportTypeGetListQuery, WbPagedResult<TransportTypeBriefDto>>
{
    public async Task<WbPagedResult<TransportTypeBriefDto>> Handle(TransportTypeGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.TransportTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<TransportTypeBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

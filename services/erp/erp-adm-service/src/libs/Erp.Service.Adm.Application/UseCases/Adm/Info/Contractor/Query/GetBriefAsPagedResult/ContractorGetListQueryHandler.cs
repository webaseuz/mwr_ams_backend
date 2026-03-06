using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class ContractorGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<ContractorGetListQuery, WbPagedResult<ContractorBriefDto>>
{
    public async Task<WbPagedResult<ContractorBriefDto>> Handle(ContractorGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Contractors
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<ContractorBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search) ||
                                     x.Inn.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

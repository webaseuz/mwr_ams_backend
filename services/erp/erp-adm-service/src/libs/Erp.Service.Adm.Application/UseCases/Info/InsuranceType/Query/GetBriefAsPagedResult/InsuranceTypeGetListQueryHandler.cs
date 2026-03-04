using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class InsuranceTypeGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<InsuranceTypeGetListQuery, WbPagedResult<InsuranceTypeBriefDto>>
{
    public async Task<WbPagedResult<InsuranceTypeBriefDto>> Handle(InsuranceTypeGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.InsuranceTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<InsuranceTypeBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(x => x.ShortName.ToLower().Contains(search) ||
                                     x.FullName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

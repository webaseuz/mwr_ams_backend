using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTransportBriefPagedResultHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<TransportGetListQuery, WbPagedResult<TransportBriefDto>>
{
    public async Task<WbPagedResult<TransportBriefDto>> Handle(TransportGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Transports
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<TransportBriefDto>(mapper, cultureHelper);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId.Value);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.ToLower();
            query = query.Where(x =>
                x.BranchName.ToLower().Contains(search) ||
                (x.DepartmentName != null && x.DepartmentName.ToLower().Contains(search)) ||
                x.TransportModelName.ToLower().Contains(search) ||
                (x.OrderCode != null && x.OrderCode.ToLower().Contains(search)) ||
                x.StateNumber.ToLower().Contains(search) ||
                x.TransportUseTypeName.ToLower().Contains(search) ||
                x.TransportBrandName.ToLower().Contains(search) ||
                x.TransportColorName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}

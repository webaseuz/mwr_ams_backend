using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UserGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<UserGetListQuery, WbPagedResult<UserBriefDto>>
{
    public async Task<WbPagedResult<UserBriefDto>> Handle(UserGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Users
            .Where(x => !x.IsDeleted)
            .MapTo<UserBriefDto>(mapper, cultureHelper);

        if (request.StateId.HasValue)
            query = query.Where(x => x.StateId == request.StateId);

        if (request.OrganizationId.HasValue)
            query = query.Where(x => x.OrganizationId == request.OrganizationId);

        if (request.HasSearch())
            query = query.Where(x => x.UserName.ToLower().Contains(request.Search!.ToLower()) ||
                                     x.PhoneNumber.ToLower().Contains(request.Search!.ToLower()));

        return await query.AsPagedResultAsync(request);
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetUserInfoQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMainAuthService authService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<GetUserInfoQuery, UserInfoDto>
{
    public async Task<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userName = authService.UserName;

        var userInfo = await context.Users
            .Where(u => u.UserName == userName && !u.IsDeleted && u.StateId == WbStateIdConst.ACTIVE)
            .ProjectTo<UserInfoDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (userInfo == null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "USER_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("USER_NOT_FOUND").ToString()
                });

        userInfo.ResolveModules();

        userInfo.UserAccess = new();

        if (userInfo.Permissions.Contains(nameof(AdmPermissionCode.OrganizationAllView)))
            userInfo.UserAccess.CanViewAllOrganizations = true;

        return userInfo;
    }
}

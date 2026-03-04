using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Job.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application;
public class GetAuthInfoQueryHandler : IRequestHandler<GetAuthInfoQuery, UserAuthInfoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMainAuthService _authService;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetAuthInfoQueryHandler(IApplicationDbContext context, IMainAuthService authService, ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _authService = authService;
        _localizationBuilder = localizationBuilder;
    }
    public async Task<UserAuthInfoDto> Handle(GetAuthInfoQuery request, CancellationToken cancellationToken)
    {
        if (_authService.IsAuthenticated)
        {
            var userId = _authService.User?.Id ?? 0;

            if (userId <= 0)
            {
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure { Key = "USER_NOT_FOUND", ErrorMessage = _localizationBuilder.For("USER_NOT_FOUND").ToString() });
            }

            var user = await _context.Users
                .Where(x => x.Id == userId)
                .Select(u => new UserAuthInfoDto
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    FullName = u.Person.FullName,
                    ShortName = u.Person.ShortName
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new WbClientException()
                   .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                   .WithErrors(new WbFailure { Key = "DATA_NOT_FOUND", ErrorMessage = _localizationBuilder.For("DATA_NOT_FOUND").ToString() });
            }

            user.Permissions = _authService.Modules.ToList();
            user.CurrentOrganizationName = _authService.CurrentOrganization?.FullName;
            user.CurrentOrganizationId = _authService.CurrentOrganization?.Id ?? 0;

            if (user.CurrentOrganizationId == 0)
            {
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure { Key = "ORGANIZATION_NOT_ASSIGNED", ErrorMessage = _localizationBuilder.For("ORGANIZATION_NOT_ASSIGNED").ToString() });
            }

            if (_authService.User.IsAdmin)
            {
                user.Apps =  await _context.Apps
                    .Where(x => x.StateId == WbStateIdConst.ACTIVE)
                    .OrderBy(a => a.Id).Select(a => new UserAppDto
                    {
                        AppId = a.Id,
                        AppName = a.ShortName,
                        AppUrl = a.AppUrl,
                        AppIcon = a.AppIcon,
                        Description = a.Description
                    })
                .ToListAsync(cancellationToken);
            }
            else
            {
                var userAppIds = await _context.UserRoles
                    .Where(a => a.StateId == WbStateIdConst.ACTIVE && a.UserId == (int)_authService.User.Id)
                    .Select(a => a.Role.AppId)
                    .Distinct()
                    .ToListAsync(cancellationToken);

                user.Apps = await _context.Apps
                    .Where(a => userAppIds.Contains(a.Id) && a.StateId == WbStateIdConst.ACTIVE)
                    .Select(a => new UserAppDto
                    {
                        AppId = a.Id,
                        AppName = a.ShortName,
                        AppUrl = a.AppUrl,
                        AppIcon = a.AppIcon,
                        Description = a.Description
                    })
                    .OrderBy(a => a.AppId)
                    .ToListAsync(cancellationToken);
            }

            return user;
        }
        return null;
    }
}

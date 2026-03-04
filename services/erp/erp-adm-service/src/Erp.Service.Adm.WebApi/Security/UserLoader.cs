using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Application;
using Microsoft.EntityFrameworkCore;
using WEBASE.AspNet;

namespace Erp.Service.Adm.WebApi;

public class IdentityLoader : IWbIdentityLoader
{
    private readonly IMainAuthService _mainAuthService;
    private readonly IApplicationDbContext _context;
    public IdentityLoader(IMainAuthService mainAuthService, IApplicationDbContext context)
    {
        _mainAuthService = mainAuthService;
        _context = context;
    }

    public object Identity => _mainAuthService.User;

    public async Task LoadAsync()
    {
        string username = _mainAuthService.UserName;

        int requestedAppId = _mainAuthService.RequestedAppId ?? _mainAuthService.AppId;

       /* var user = await _context.Users.MapToAuthModel(requestedAppId)
            .FirstOrDefaultAsync(a => a.UserName.ToLower() == username.ToLower());

        _mainAuthService.SetUser(user);*/

        await Task.CompletedTask;
    }
}

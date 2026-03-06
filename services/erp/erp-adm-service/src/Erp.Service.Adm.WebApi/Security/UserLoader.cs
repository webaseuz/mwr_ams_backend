using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Application;
using Microsoft.EntityFrameworkCore;
using WEBASE.AspNet;

// ====== BFF MODE IMPORTS (uncomment when switching back to BFF) ======
// (no extra imports needed for BFF mode)
// ====== END BFF MODE IMPORTS ======

// ====== DIRECT JWT MODE IMPORTS ======
using Microsoft.AspNetCore.Http;
// ====== END DIRECT JWT MODE IMPORTS ======

namespace Erp.Service.Adm.WebApi;

public class IdentityLoader : IWbIdentityLoader
{
    private readonly IMainAuthService _mainAuthService;
    private readonly IApplicationDbContext _context;

    // ====== DIRECT JWT MODE FIELD ======
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPasswordHasher _passwordHasher;
    // ====== END DIRECT JWT MODE FIELD ======

    public IdentityLoader(
        IMainAuthService mainAuthService,
        IApplicationDbContext context,
        // ====== DIRECT JWT MODE CTOR PARAMS ======
        IHttpContextAccessor httpContextAccessor,
        IPasswordHasher passwordHasher
        // ====== END DIRECT JWT MODE CTOR PARAMS ======
        )
    {
        _mainAuthService = mainAuthService;
        _context = context;

        // ====== DIRECT JWT MODE CTOR BODY ======
        _httpContextAccessor = httpContextAccessor;
        _passwordHasher = passwordHasher;
        // ====== END DIRECT JWT MODE CTOR BODY ======
    }

    public object Identity => _mainAuthService.User;

    public async Task LoadAsync()
    {
        // ====== BFF MODE (uncomment when switching back to BFF) ======
        // string username = _mainAuthService.UserName;
        // int requestedAppId = _mainAuthService.RequestedAppId ?? _mainAuthService.AppId;
        // var user = await _context.Users.MapToAuthModel(requestedAppId)
        //     .FirstOrDefaultAsync(a => a.UserName.ToLower() == username.ToLower());
        // _mainAuthService.SetUser(user);
        // ====== END BFF MODE ======

        // ====== DIRECT JWT MODE ======
        var authHeader = _httpContextAccessor.HttpContext?.Request.Headers.Authorization.FirstOrDefault();
        if (authHeader != null && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            var token = authHeader["Bearer ".Length..].Trim();
            var tokenHash = _passwordHasher.Compute(token);

            var userIdentity = await _context.UserTokens
                .Where(ut => ut.TokenHash == tokenHash && !ut.IsDeleted && ut.ExpireAt > DateTime.UtcNow)
                .Select(ut => ut.UserIdentity)
                .FirstOrDefaultAsync();

            if (userIdentity != null)
                _mainAuthService.ResetUserName(userIdentity);
        }
        // ====== END DIRECT JWT MODE ======
    }
}

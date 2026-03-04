using Erp.Core.Security;
using Erp.Core.Service.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using WEBASE.i18n;

namespace Erp.Core.Service.Infrastructure;

public class CultureHelper : BaseCultureHelper
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthService _authService;
    public CultureHelper(CultureConfig config, IApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IAuthService authService)
        : base(config)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _authService = authService;
    }

    protected override IEnumerable<CultureModel> GetCultures()
    {
        return _context.Languages.Select(a => new CultureModel(a.Id, a.Code, a.FullName));
    }

    protected override CultureModel GetCurrentCulture()
    {
        if (_httpContextAccessor.HttpContext is not null)
        {
            var header = _httpContextAccessor.HttpContext.Request.Headers;
            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(ApplicationHeaderConst.Language, out StringValues Lang) &&
                !StringValues.IsNullOrEmpty(Lang) && Cultures.Any(a => a.Code == Lang))
                return Cultures.First(a => a.Code == Lang);
        }

        if (_authService.IsAuthenticated && _authService.User != null)
            return Cultures.FirstOrDefault(culture => culture.Code == _authService.User.LanguageCode) ?? DefaultCulture;
        // Write user language if not found

        return DefaultCulture;
    }

    protected override CultureModel GetDefaultCulture()
    {
        return Cultures.FirstOrDefault(x => x.Code == ServiceAppSettings.ServiceInstance.Culture.DefaultCulture);
    }
}

using AutoPark.Application;
using Bms.WEBASE.Config;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AutoPark.Infrastructure;

public class CultureHelper :
    BaseCultureHelper
{
    private readonly IReadEfCoreContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CultureHelper(CultureConfig config,
                         IReadEfCoreContext context,
                         IHttpContextAccessor httpContextAccessor)
        : base(config)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    protected override IEnumerable<CultureModel> GetCultures()
        => _context.Languages.AsEnumerable().Select(a => new CultureModel(a.Id, a.Code, a.FullName));


    protected override CultureModel GetCurrentCulture()
    {
        if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Lang", out StringValues Lang) &&
            !StringValues.IsNullOrEmpty(Lang) && Cultures.Any(a => a.Code == Lang))
            return Cultures.First(a => a.Code == Lang);

        return DefaultCulture;
    }

    protected override CultureModel GetDefaultCulture()
        => Cultures.FirstOrDefault(a => a.Code == "ru");

}
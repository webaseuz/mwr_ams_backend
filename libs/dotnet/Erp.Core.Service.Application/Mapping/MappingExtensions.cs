using AutoMapper;
using AutoMapper.QueryableExtensions;
using WEBASE.i18n;

namespace Erp.Core.Service.Application;

public static class MappingExtensions
{
    public static IQueryable<TDto> MapTo<TDto>(this IQueryable source, IMapper mapper, ICultureHelper cultureHelper)
    {
        var valuePairs = new Dictionary<string, object>
        {
            { "cultureId", cultureHelper.CurrentCulture.Id }
        };

        return source.ProjectTo<TDto>(mapper.ConfigurationProvider, valuePairs);
    }
}

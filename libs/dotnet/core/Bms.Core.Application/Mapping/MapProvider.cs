using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bms.WEBASE.Helpers;
using WEBASE.Security.Abstraction;

namespace Bms.Core.Application.Mapping;

public class MapProvider :
    IMapProvider
{
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;
    private readonly IBaseAuthService _authService;

    public MapProvider(IMapper mapper,
        ICultureHelper cultureHelper,
        IBaseAuthService authService)
    {
        _mapper = mapper;
        _cultureHelper = cultureHelper;
        _authService = authService;
    }

    public TDestination Map<TSource, TDestination>(TSource dest)
        where TSource : class
        where TDestination : class
    {
        return _mapper.Map<TSource, TDestination>(dest);
    }

    public TDestination Map<TSource, TDestination>(TSource source,
                                                   TDestination dest)
        where TSource : class
        where TDestination : class
    {
        return _mapper.Map(source, dest);
    }

    public IQueryable<TDestination> MapCollection<TSource, TDestination>(IQueryable<TSource> source)
            where TSource : class
            where TDestination : class
    {
        if (source == null)
            throw new MapperException(nameof(source));

        var defaultParameters = new
        {
            lang = _cultureHelper.CurrentCulture.Id,
            authService = _authService
        };

        return source.ProjectTo<TDestination>(configuration: _mapper.ConfigurationProvider,
                                              parameters: defaultParameters);
    }
}
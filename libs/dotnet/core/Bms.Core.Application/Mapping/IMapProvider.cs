namespace Bms.Core.Application.Mapping;

//This is for general encapsulation of mapping logic.If we want change AutoMapper to alternative we should change only implementation of this interface
public interface IMapProvider
{
    TDestination Map<TSource, TDestination>(TSource dest)
        where TSource : class
        where TDestination : class;

    public TDestination Map<TSource, TDestination>(TSource source, TDestination dest)
        where TSource : class
        where TDestination : class;

    IQueryable<TDestination> MapCollection<TSource, TDestination>(IQueryable<TSource> source)
        where TSource : class
        where TDestination : class;
}
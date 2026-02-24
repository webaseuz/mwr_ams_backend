using AutoMapper;
using Bms.WEBASE.DependencyInjection;
using System.Linq.Expressions;

namespace Bms.Core.Application;

public static class MappingExtension
{
    private static string GetTranslationOrDefault<TTranslate>(
        this IEnumerable<TTranslate> translates,
        Func<TTranslate, bool> predicate,
        Func<TTranslate, string> selector,
        string defaultValue)
    {
        var translation = translates.FirstOrDefault(predicate);
        return translation != null ? selector(translation) : defaultValue;
    }

    public static IMappingExpression<TSource, TDestination> ForMemberEnumTranslate<TSource, TDestination, TTranslate, TTranslateColumn>(
        this IMappingExpression<TSource, TDestination> mappingExpression,
        Expression<Func<TDestination, string>> destinationMember,
        Func<TSource, IEnumerable<TTranslate>> translatesSelector,
        Func<TTranslateColumn, int, Expression<Func<TTranslate, bool>>> getExpr,
        TTranslateColumn column,
        Func<TSource, string> defaultSelector)
            where TTranslate : EnumTranslateEntity<TTranslate, TTranslateColumn>
            where TTranslateColumn : struct
    {
        return mappingExpression.ForMember(destinationMember, opts => opts.MapFrom(source =>
            translatesSelector(source)
                .GetTranslationOrDefault(
                    getExpr(column, ServiceProvider.CultureHelper.CurrentCulture.Id).Compile(),
                    t => t.ColumnName,
                    defaultSelector(source))));
    }

    public static IMappingExpression<TSource, TDestination> ForMemberTranslate<TSource, TDestination, TTranslate, TTranslateColumn>(
        this IMappingExpression<TSource, TDestination> mappingExpression,
        Expression<Func<TDestination, string>> destinationMember,
        Func<TSource, IEnumerable<TTranslate>> translatesSelector,
        Func<TTranslateColumn, int, Expression<Func<TTranslate, bool>>> getExpr,
        TTranslateColumn column,
        Func<TSource, string> defaultSelector)
            where TTranslate : TranslateEntity<TTranslate, TTranslateColumn>
            where TTranslateColumn : struct
    {
        return mappingExpression.ForMember(destinationMember, opts => opts.MapFrom(source =>
            translatesSelector(source)
                .GetTranslationOrDefault(
                    getExpr(column, ServiceProvider.CultureHelper.CurrentCulture.Id).Compile(),
                    t => t.TranslateText,
                    defaultSelector(source))));
    }


    public static IMappingExpression<TSource, TDestination> ForDefaultMember<TSource, TDestination, TMember>(
        this IMappingExpression<TSource, TDestination> mappingExpression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Func<TSource, TMember> sourceSelector)
        => mappingExpression.ForMember(destinationMember, opts => opts.MapFrom(src => sourceSelector(src)));

}

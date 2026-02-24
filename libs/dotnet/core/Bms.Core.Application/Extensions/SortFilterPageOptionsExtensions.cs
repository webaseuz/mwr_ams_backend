
using Bms.WEBASE.Models;

namespace Bms.Core.Application;
public static class SortFilterPageOptionsExtensions
{
    public static bool IsValidSortBy<T>(this SortFilterPageOptions options)
    {
        var properties = typeof(T).GetProperties()
            .Where(a => !IsNullable(a.PropertyType))
            .ToList();

        return properties.Any(a => a.Name.ToLower() == options.SortBy.ToLower());
    }

    public static bool IsValidSortBy<T>(this ISortFilterOptions options)
    {
        var properties = typeof(T).GetProperties()
            .Where(a => !IsNullable(a.PropertyType))
            .ToList();

        return properties.Any(a => a.Name.ToLower() == options.SortBy.ToLower());
    }

    public static bool IsNullable(Type type)
    {
        return Nullable.GetUnderlyingType(type) != null || !type.IsValueType;
    }
}
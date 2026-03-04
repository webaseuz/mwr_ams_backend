/*using WEBASE;

namespace Erp.Core;

public static class EntityCommandExtensions
{
    public static void AddByUniqueFKTo<TDto, TEntity, TId>(this IEnumerable<TDto> dtoList, ICollection<TEntity> entityNavigationProperty)
        where TDto : TranslateCommand
        where TEntity : class, IWbTranslateEntity<TId>, new()
        where TId : struct
    {
        HashSet<object> hashSet = new HashSet<object>();
        foreach (TDto dto in dtoList)
        {
            if (!hashSet.Contains(dto.GetUniqueForeignKey()))
            {
                hashSet.Add(dto.GetUniqueForeignKey());

                dto.CreateEntity<TDto, TEntity, TId>(out TEntity entity);

                entityNavigationProperty.Add(entity);
            }
        }
    }

    public static void ApplyChangesByUniqueFKTo<TDto, TEntity, TId>(this IEnumerable<TDto> dtoList, ICollection<TEntity> entityNavigationProperty)
        where TDto : TranslateCommand
        where TEntity : class, IWbTranslateEntity<TId>, IHaveUniqueForeignKey, new()
        where TId : struct
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TEntity> list = new List<TEntity>();

        foreach (TEntity entity in entityNavigationProperty)
        {
            if (dtoList.Any((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())))
            {
                if (dictionary.ContainsKey(entity.GetUniqueForeignKey()))
                {
                    list.Add(entity);
                }
                else
                {
                    dictionary.Add(entity.GetUniqueForeignKey(), entity);
                }
            }
            else
            {
                list.Add(entity);
            }
        }

        foreach (TEntity item in list)
        {
            entityNavigationProperty.Remove(item);
        }

        foreach (TDto dto in dtoList)
        {
            if (dictionary.ContainsKey(dto.GetUniqueForeignKey()))
            {
                dto.UpdateEntity<TDto, TEntity, TId>(dictionary[dto.GetUniqueForeignKey()]);
            }
            else
            {
                dto.CreateEntity<TDto, TEntity, TId>(out TEntity entity);

                entityNavigationProperty.Add(entity);
            }
        }

        dictionary.Clear();
    }

    public static void CreateEntity<TDto, TEntity, TId>(this TDto translateCommand, out TEntity entity)
        where TEntity : class, IWbTranslateEntity<TId>, new()
        where TDto : TranslateCommand
        where TId : struct
    {
        entity = new TEntity
        {
            ColumnName = translateCommand.ColumnName.ToString(),
            LanguageId = translateCommand.LanguageId,
            TranslateText = translateCommand.TranslateText
        };
    }

    public static void UpdateEntity<TDto, TEntity, TId>(this TDto translateCommand, TEntity entity)
        where TEntity : class, IWbTranslateEntity<TId>, new()
        where TDto : TranslateCommand
        where TId : struct
    {
        entity = new TEntity
        {
            ColumnName = translateCommand.ColumnName.ToString(),
            LanguageId = translateCommand.LanguageId,
            TranslateText = translateCommand.TranslateText
        };
    }
}
*/

namespace Erp.Core;

public static class EntityCommandExtensions
{
    public static void AddByUniqueFKTo<TDto, TEntity>(this IEnumerable<TDto> dtoList, ICollection<TEntity> entityNavigationProperty)
        where TDto : TranslateCommand
        where TEntity : class, new()
    {
        HashSet<object> hashSet = new HashSet<object>();
        foreach (TDto dto in dtoList)
        {
            if (!hashSet.Contains(dto.GetUniqueForeignKey()))
            {
                hashSet.Add(dto.GetUniqueForeignKey());
                dto.CreateEntity<TDto, TEntity>(out TEntity entity);
                entityNavigationProperty.Add(entity);
            }
        }
    }

    public static void ApplyChangesByUniqueFKTo<TDto, TEntity>(this IEnumerable<TDto> dtoList, ICollection<TEntity> entityNavigationProperty)
        where TDto : TranslateCommand
        where TEntity : class, IHaveUniqueForeignKey, new()
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TEntity> list = new List<TEntity>();

        foreach (TEntity entity in entityNavigationProperty)
        {
            if (dtoList.Any((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())))
            {
                if (dictionary.ContainsKey(entity.GetUniqueForeignKey()))
                {
                    list.Add(entity);
                }
                else
                {
                    dictionary.Add(entity.GetUniqueForeignKey(), entity);
                }
            }
            else
            {
                list.Add(entity);
            }
        }

        foreach (TEntity item in list)
        {
            entityNavigationProperty.Remove(item);
        }

        foreach (TDto dto in dtoList)
        {
            if (dictionary.ContainsKey(dto.GetUniqueForeignKey()))
            {
                dto.UpdateEntity<TDto, TEntity>(dictionary[dto.GetUniqueForeignKey()]);
            }
            else
            {
                dto.CreateEntity<TDto, TEntity>(out TEntity entity);
                entityNavigationProperty.Add(entity);
            }
        }

        dictionary.Clear();
    }

    public static void CreateEntity<TDto, TEntity>(this TDto translateCommand, out TEntity entity)
        where TEntity : class, new()
        where TDto : TranslateCommand
    {
        entity = new TEntity();

        var entityType = typeof(TEntity);
        var columnNameProp = entityType.GetProperty("ColumnName");
        var languageIdProp = entityType.GetProperty("LanguageId");
        var translateTextProp = entityType.GetProperty("TranslateText");

        if (columnNameProp != null && columnNameProp.CanWrite)
        {
            columnNameProp.SetValue(entity, translateCommand.ColumnName.ToString());
        }

        if (languageIdProp != null && languageIdProp.CanWrite)
        {
            languageIdProp.SetValue(entity, translateCommand.LanguageId);
        }

        if (translateTextProp != null && translateTextProp.CanWrite)
        {
            translateTextProp.SetValue(entity, translateCommand.TranslateText);
        }
    }

    public static void UpdateEntity<TDto, TEntity>(this TDto translateCommand, TEntity entity)
        where TEntity : class, new()
        where TDto : TranslateCommand
    {
        var entityType = typeof(TEntity);
        var columnNameProp = entityType.GetProperty("ColumnName");
        var languageIdProp = entityType.GetProperty("LanguageId");
        var translateTextProp = entityType.GetProperty("TranslateText");

        if (columnNameProp != null && columnNameProp.CanWrite)
        {
            columnNameProp.SetValue(entity, translateCommand.ColumnName.ToString());
        }

        if (languageIdProp != null && languageIdProp.CanWrite)
        {
            languageIdProp.SetValue(entity, translateCommand.LanguageId);
        }

        if (translateTextProp != null && translateTextProp.CanWrite)
        {
            translateTextProp.SetValue(entity, translateCommand.TranslateText);
        }
    }
}

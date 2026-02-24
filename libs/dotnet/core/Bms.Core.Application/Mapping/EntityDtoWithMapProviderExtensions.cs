using Bms.WEBASE.Models;

namespace Bms.Core.Application.Mapping;

public static class EntityDtoWithMapProviderExtensions
{
    #region Simple

    public static TEntity CreateEntity<TDto, TEntity>(this TDto dto, IMapProvider mapper)
        where TEntity : class
        where TDto : class
        => mapper.Map<TDto, TEntity>(dto);

    public static void UpdateEntity<TDto, TEntity>(this TDto dto, TEntity entity, IMapProvider mapper)
        where TEntity : class
        where TDto : class
    {
        mapper.Map(dto, entity);
    }

    public static void AddTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null)
            where TDto : class
            where TEntity : class
    {
        foreach (TDto dto in dtoList)
        {
            TEntity val = dto.CreateEntity<TDto, TEntity>(mapper);
            onAddToNavigationProperty?.Invoke(val, dto);
            entityNavigationProperty.Add(val);
        }
    }

    public static void ApplyChangesTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class, IHaveId where TEntity : class, IHaveId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TEntity> list = new List<TEntity>();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            if (dtoList.Any((TDto a) => a.GetId().Equals(entity.GetId())))
                dictionary.Add(entity.GetId(), entity);
            else
                list.Add(entity);
        }

        foreach (TEntity item in list)
            entityNavigationProperty.Remove(item);

        foreach (TDto dto in dtoList)
        {
            if (dictionary.ContainsKey(dto.GetId()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[dto.GetId()], dto);
                dto.UpdateEntity(dictionary[dto.GetId()], mapper);
            }
            else
            {
                TEntity val = dto.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, dto);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesTo<TId, TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TId : struct where TDto : class, IHaveIdProp<TId> where TEntity : class, IHaveIdProp<TId>
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TEntity> list = new List<TEntity>();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            if (dtoList.Any((TDto a) => a.Id.Equals(entity.Id)))
            {
                dictionary.Add(entity.Id, entity);
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
            if (dictionary.ContainsKey(dto.Id))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[dto.Id], dto);
                dto.UpdateEntity(dictionary[dto.Id], mapper);
            }
            else
            {
                TEntity val = dto.CreateEntity<TDto, TEntity>(mapper);
                entityNavigationProperty.Add(val);
                onAddToNavigationProperty?.Invoke(val, dto);
            }
        }

        dictionary.Clear();
    }
    #endregion

    #region UniqueFK

    #region UniqueFKList
    public static void AddFromForeignKeys<TForeignKey, TManyToManyEntity>(
        this ICollection<TManyToManyEntity> manyToManyEntityNavigationProperty,
        IEnumerable<TForeignKey> foreignKeyList,
        Action<TForeignKey, TManyToManyEntity> onAddToNavigationProperty = null)
            where TManyToManyEntity : class,
                                      IHaveSingleUniqueForeignKey<TForeignKey>
    {
        foreach (TForeignKey foreignKey in foreignKeyList)
        {
            TManyToManyEntity val = Activator.CreateInstance<TManyToManyEntity>();

            val.SetUniqueForeignKey(foreignKey);

            manyToManyEntityNavigationProperty.Add(val);
        }
    }

    public static void UpdateFromForeignKeys<TForeignKey, TManyToManyEntity>(
        this ICollection<TManyToManyEntity> manyToManyEntityNavigationProperty,
        IEnumerable<TForeignKey> foreignKeyList,
        Action<TForeignKey, TManyToManyEntity> onAddToNavigationProperty = null)
            where TManyToManyEntity : class,
                                      IHaveSingleUniqueForeignKey<TForeignKey>
    {
        HashSet<TForeignKey> foundedEntitiesForeignKeys = new HashSet<TForeignKey>();

        foreach (TManyToManyEntity item in manyToManyEntityNavigationProperty)
        {
            if (foreignKeyList.Contains((TForeignKey)item.GetUniqueForeignKey()))
                if (foundedEntitiesForeignKeys.Contains((TForeignKey)item.GetUniqueForeignKey()))
                    manyToManyEntityNavigationProperty.Remove(item);
                else
                    foundedEntitiesForeignKeys.Add((TForeignKey)item.GetUniqueForeignKey());
            else
                manyToManyEntityNavigationProperty.Remove(item);
        }

        manyToManyEntityNavigationProperty.AddFromForeignKeys(foreignKeyList.Where((TForeignKey a) => !foundedEntitiesForeignKeys.Contains(a)));

        foundedEntitiesForeignKeys.Clear();
    }

    #endregion

    public static void AddByUniqueFKTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null)
            where TDto : class, IHaveUniqueForeignKey where TEntity : class
    {
        HashSet<object> hashSet = new HashSet<object>();
        foreach (TDto dto in dtoList)
        {
            if (!hashSet.Contains(dto.GetUniqueForeignKey()))
            {
                hashSet.Add(dto.GetUniqueForeignKey());
                TEntity val = dto.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, dto);
                entityNavigationProperty.Add(val);
            }
        }
    }

    public static void ApplyChangesByUniqueFKTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class, IHaveUniqueForeignKey where TEntity : class, IHaveUniqueForeignKey
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TEntity> list = new List<TEntity>();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
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
                onUpdateFromNavigationProperty?.Invoke(dictionary[dto.GetUniqueForeignKey()], dto);
                dto.UpdateEntity(dictionary[dto.GetUniqueForeignKey()], mapper);
            }
            else
            {
                TEntity val = dto.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, dto);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }
    #endregion

    #region StateId related

    public static void ApplyChangesByUniqueFKAndStateIdTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class, IHaveUniqueForeignKey where TEntity : class, IHaveUniqueForeignKey, IHaveStateId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TDto> list = dtoList.ToList();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())).ToArray();
            if (array.Any())
            {
                if (entity.StateId == 1)
                {
                    dictionary.Add(entity.GetUniqueForeignKey(), entity);
                    continue;
                }

                TDto[] array2 = array;
                foreach (TDto item in array2)
                {
                    list.Remove(item);
                }
            }
            else
            {
                entity.StateId = 2;
            }
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetUniqueForeignKey()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetUniqueForeignKey()], item2);
                item2.UpdateEntity(dictionary[item2.GetUniqueForeignKey()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByStateIdTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class,
                         IHaveId where TEntity : class, IHaveId, IHaveStateId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TDto> list = dtoList.ToList();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetId().Equals(entity.GetId())).ToArray();
            if (array.Any())
            {
                if (entity.StateId == 1)
                {
                    dictionary.Add(entity.GetId(), entity);
                    continue;
                }

                TDto[] array2 = array;
                foreach (TDto item in array2)
                {
                    list.Remove(item);
                }
            }
            else
            {
                entity.StateId = 2;
            }
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetId()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetId()], item2);
                item2.UpdateEntity(dictionary[item2.GetId()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByStateIdTo<TId, TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
        where TId : struct where TDto : class, IHaveIdProp<TId> where TEntity : class, IHaveIdProp<TId>, IHaveStateId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TDto> list = dtoList.ToList();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.Id.Equals(entity.Id)).ToArray();
            if (array.Any())
            {
                if (entity.StateId == 1)
                {
                    dictionary.Add(entity.Id, entity);
                    continue;
                }

                TDto[] array2 = array;
                foreach (TDto item in array2)
                {
                    list.Remove(item);
                }
            }
            else
            {
                entity.StateId = 2;
            }
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.Id))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.Id], item2);
                item2.UpdateEntity(dictionary[item2.Id], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByUniqueFKAndSoftStateIdTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
        where TDto : class, IHaveUniqueForeignKey where TEntity : class, IHaveUniqueForeignKey, IHaveSoftStateId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TDto> list = dtoList.ToList();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())).ToArray();
            if (array.Any())
            {
                if (entity.StateId == 1)
                {
                    dictionary.Add(entity.GetUniqueForeignKey(), entity);
                    continue;
                }

                TDto[] array2 = array;
                foreach (TDto item in array2)
                {
                    list.Remove(item);
                }
            }
            else
            {
                entity.MarkAsPassive();
            }
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetUniqueForeignKey()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetUniqueForeignKey()], item2);
                item2.UpdateEntity(dictionary[item2.GetUniqueForeignKey()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesBySoftStateIdTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
        where TDto : class, IHaveId where TEntity : class, IHaveId, IHaveSoftStateId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TDto> list = dtoList.ToList();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetId().Equals(entity.GetId())).ToArray();
            if (array.Any())
            {
                if (entity.StateId == 1)
                {
                    dictionary.Add(entity.GetId(), entity);
                    continue;
                }

                TDto[] array2 = array;
                foreach (TDto item in array2)
                {
                    list.Remove(item);
                }
            }
            else
            {
                entity.MarkAsPassive();
            }
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetId()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetId()], item2);
                item2.UpdateEntity(dictionary[item2.GetId()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesBySoftStateIdTo<TId, TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TId : struct
            where TDto : class, IHaveIdProp<TId>
            where TEntity : class, IHaveIdProp<TId>, IHaveSoftStateId
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
        List<TDto> list = dtoList.ToList();
        if (entityNavigationPropertyFilter == null)
        {
            entityNavigationPropertyFilter = (TEntity a) => true;
        }

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.Id.Equals(entity.Id)).ToArray();
            if (array.Any())
            {
                if (entity.StateId == 1)
                {
                    dictionary.Add(entity.Id, entity);
                    continue;
                }

                TDto[] array2 = array;
                foreach (TDto item in array2)
                {
                    list.Remove(item);
                }
            }
            else
            {
                entity.MarkAsPassive();
            }
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.Id))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.Id], item2);
                item2.UpdateEntity(dictionary[item2.Id], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }
    #endregion

    #region IsDeleted related

    public static void ApplyChangesByUniqueFKAndIsDeletedTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class, IHaveUniqueForeignKey
            where TEntity : class, IHaveUniqueForeignKey, IHaveIsDeleted
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TDto> list = dtoList.ToList();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())).ToArray();

            if (array.Any())
            {
                if (!entity.IsDeleted)
                {
                    dictionary.Add(entity.GetUniqueForeignKey(), entity);
                    continue;
                }

                TDto[] array2 = array;

                foreach (TDto item in array2)
                    list.Remove(item);
            }
            else
                entity.IsDeleted = true;
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetUniqueForeignKey()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetUniqueForeignKey()], item2);
                item2.UpdateEntity(dictionary[item2.GetUniqueForeignKey()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByIsDeletedTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class, IHaveId where TEntity : class, IHaveId, IHaveIsDeleted
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TDto> list = dtoList.ToList();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetId().Equals(entity.GetId())).ToArray();

            if (array.Any())
            {
                if (!entity.IsDeleted)
                {
                    dictionary.Add(entity.GetId(), entity);
                    continue;
                }

                TDto[] array2 = array;

                foreach (TDto item in array2)
                    list.Remove(item);
            }
            else
                entity.IsDeleted = true;
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetId()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetId()], item2);
                item2.UpdateEntity(dictionary[item2.GetId()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByIsDeletedTo<TId, TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TId : struct
            where TDto : class, IHaveIdProp<TId>
            where TEntity : class, IHaveIdProp<TId>, IHaveIsDeleted
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TDto> list = dtoList.ToList();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.Id.Equals(entity.Id)).ToArray();

            if (array.Any())
            {
                if (!entity.IsDeleted)
                {
                    dictionary.Add(entity.Id, entity);
                    continue;
                }

                TDto[] array2 = array;

                foreach (TDto item in array2)
                    list.Remove(item);
            }
            else
                entity.IsDeleted = true;
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.Id))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.Id], item2);
                item2.UpdateEntity(dictionary[item2.Id], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }


    public static void ApplyChangesByUniqueFKAndISoftDeletableTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null)
            where TDto : class, IHaveUniqueForeignKey where TEntity : class, IHaveUniqueForeignKey, ISoftDeletable
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TDto> list = dtoList.ToList();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())).ToArray();

            if (array.Any())
            {
                if (!entity.IsDeleted)
                {
                    dictionary.Add(entity.GetUniqueForeignKey(), entity);
                    continue;
                }

                TDto[] array2 = array;

                foreach (TDto item in array2)
                    list.Remove(item);
            }
            else
                entity.MarkAsDeleted();
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetUniqueForeignKey()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetUniqueForeignKey()], item2);
                item2.UpdateEntity(dictionary[item2.GetUniqueForeignKey()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByISoftDeletableTo<TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null) where TDto : class, IHaveId where TEntity : class, IHaveId, ISoftDeletable
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TDto> list = dtoList.ToList();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.GetId().Equals(entity.GetId())).ToArray();

            if (array.Any())
            {
                if (!entity.IsDeleted)
                {
                    dictionary.Add(entity.GetId(), entity);
                    continue;
                }

                TDto[] array2 = array;

                foreach (TDto item in array2)
                    list.Remove(item);
            }
            else
                entity.MarkAsDeleted();
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.GetId()))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.GetId()], item2);
                item2.UpdateEntity(dictionary[item2.GetId()], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }

    public static void ApplyChangesByISoftDeletableTo<TId, TDto, TEntity>(
        this IEnumerable<TDto> dtoList,
        ICollection<TEntity> entityNavigationProperty,
        IMapProvider mapper,
        Action<TEntity, TDto> onAddToNavigationProperty = null,
        Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
        Func<TEntity, bool> entityNavigationPropertyFilter = null) where TId : struct where TDto : class, IHaveIdProp<TId> where TEntity : class, IHaveIdProp<TId>, ISoftDeletable
    {
        Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();

        List<TDto> list = dtoList.ToList();

        if (entityNavigationPropertyFilter == null)
            entityNavigationPropertyFilter = (TEntity a) => true;

        foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
        {
            TDto[] array = list.Where((TDto a) => a.Id.Equals(entity.Id)).ToArray();

            if (array.Any())
            {
                if (!entity.IsDeleted)
                {
                    dictionary.Add(entity.Id, entity);
                    continue;
                }

                TDto[] array2 = array;

                foreach (TDto item in array2)
                    list.Remove(item);
            }
            else
                entity.MarkAsDeleted();
        }

        foreach (TDto item2 in list)
        {
            if (dictionary.ContainsKey(item2.Id))
            {
                onUpdateFromNavigationProperty?.Invoke(dictionary[item2.Id], item2);
                item2.UpdateEntity(dictionary[item2.Id], mapper);
            }
            else
            {
                TEntity val = item2.CreateEntity<TDto, TEntity>(mapper);
                onAddToNavigationProperty?.Invoke(val, item2);
                entityNavigationProperty.Add(val);
            }
        }

        dictionary.Clear();
    }
    #endregion
}
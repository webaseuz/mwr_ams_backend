using Microsoft.EntityFrameworkCore;
using StatusGeneric;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.LogSdk.DAL.Repositories;

namespace WEBASE.LogSdk.BLL.Services;

public class BaseService<TKey, TEntity> : StatusGenericHandler, IEntityService<TKey, TEntity>
    where TEntity : class, IEntity<TKey>
{
    public BaseService(Repository<TKey, TEntity> repository)
    {
        Repository = repository;
    }

    public Repository<TKey, TEntity> Repository { get; }

    public virtual IQueryable<TEntity> AllAsQueryable
    {
        get
        {
            return Repository.AllAsQueryable;
        }
    }

    public virtual TEntity[] All
    {
        get
        {
            return AllAsQueryable.ToArray();
        }
    }

    public virtual DbSet<TEntity> AsObjectQuery()
    {
        return Repository.DbSet;
    }

    public virtual TEntity ById(TKey id)
    {
        return Repository.ById(id);
    }

    public virtual TEntity Create(TEntity entity, bool autoSave = true)
    {
        return Repository.Create(entity, autoSave);
    }

    public virtual TEntity Update(TEntity entity, bool autoSave = true)
    {
        return Repository.Update(entity, autoSave);
    }

    public virtual void Delete(TKey id, bool autoSave = true)
    {
        Repository.Delete(id, autoSave);
    }
}
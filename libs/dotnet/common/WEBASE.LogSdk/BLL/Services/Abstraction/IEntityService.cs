using Microsoft.EntityFrameworkCore;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.LogSdk.DAL.Repositories;

namespace WEBASE.LogSdk.BLL.Services;

public interface IEntityService<TKey, TEntity>
    where TEntity : class, IEntity<TKey>
{
    /// <summary>
    /// Gets the repository.
    /// </summary>
    Repository<TKey, TEntity> Repository { get; }

    IQueryable<TEntity> AllAsQueryable { get; }

    TEntity[] All { get; }
    DbSet<TEntity> AsObjectQuery();
    TEntity ById(TKey id);
    TEntity Create(TEntity entity, bool autoSave = true);
    TEntity Update(TEntity entity, bool autoSave = true);
    void Delete(TKey id, bool autoSave = true);
}

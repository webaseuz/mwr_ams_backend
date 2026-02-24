using StatusGeneric;
using System.Linq.Expressions;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.DAL.Repositories;

public interface IRepository<TKey, TEntity> : IStatusGeneric
    where TEntity : class, IEntity<TKey>
{
    /// <summary>
    /// Get an entity by its primary key.
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
        string includeProperties = "");

    /// <summary>
    /// Retrieves a single entity by its primary key.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <param name="applayFilter">If true, applies global filters (e.g., IsDeleted, IsActive); otherwise, ignores them.</param>
    /// <returns>The entity matching the given key, or null if not found.</returns>

    TEntity ById(TKey id, bool applayFilter);

    /// <summary>
    /// Gets all entities as an <see cref="IQueryable{TEntity}"/> to allow further querying (e.g., filtering, sorting, projection).
    /// </summary>
    IQueryable<TEntity> AllAsQueryable { get; }

    /// <summary>
    /// Berilgan shart (predicate) asosida ma’lumotlar bazasidan entity’lar ro‘yxatini qaytaradi.
    /// </summary>
    /// <param name="predicate">Entity ustida qo‘llaniladigan shart (filter)</param>
    /// <returns>Tegishli entity’lar ro‘yxati</returns>

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Berilgan Entity’ni ma’lumotlar bazasiga qo‘shadi va avtomatik save qiladi.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="autoSave"></param>
    /// <returns></returns>
    TEntity Create(TEntity entity, bool autoSave = true);

    /// <summary>
    /// Berilgan entity’ni ma’lumotlar bazasidan ochiradi va avtomatik save qilmaydi.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="autoSave"></param>
    /// <returns></returns>
    TEntity Delete(TKey id, bool autoSave = true);

    /// <summary>
    /// Berilgan entity’ni ma’lumotlar bazada yangilanadi va avtomatik save qiladi.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="autoSave"></param>
    /// <returns></returns>
    TEntity Update(TEntity entity, bool autoSave = true);

    /// <summary>
    /// Sizning entity’laringizni ma’lumotlar bazasiga saqlaydi.
    /// </summary>
    /// <returns></returns>
    int Save();

}

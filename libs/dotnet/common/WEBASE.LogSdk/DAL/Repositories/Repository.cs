using Microsoft.EntityFrameworkCore;
using StatusGeneric;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.DAL.Repositories;

public class Repository<TId, TEntity> : StatusGenericHandler, IRepository<TId, TEntity>
    where TEntity : class, IEntity<TId>
{
    public readonly DbContext DbContext;
    public readonly DbSet<TEntity> DbSet;

    public Repository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> AllAsQueryable
    {
        get => InjectFilter(DbSet.AsQueryable());
    }

    public virtual TEntity ById(TId id, bool applayFilter = true)
    {
        var entity = ByIdQuery(applayFilter)
            .FirstOrDefault(e => e.Id.Equals(id));

        if (entity == null)
            AddEntityNotFoundError();
        return entity!;
    }

    public TEntity Create(TEntity entity, bool autoSave = true)
    {
        var entry = DbSet.Add(entity);
        DbContext.Entry(entity).State = EntityState.Added;

        if (autoSave)
            Save();

        return entry.Entity;
    }

    public virtual TEntity Delete(TId id, bool autoSave = true)
    {
        var entity = ById(id, true);

        if (HasErrors)
            return null!;

        DbSet.Remove(entity);
        DbContext.Entry(entity).State = EntityState.Deleted;

        if (autoSave)
            Save();

        return entity;
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return AllAsQueryable.Where(predicate);
    }

    public virtual async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null!,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = DbSet;

        if (filter != null)
            query = query.Where(filter);

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        else
            return await query.ToListAsync();
    }

    public int Save()
        => DbContext.SaveChanges();

    protected virtual IQueryable<TEntity> ByIdQuery(bool applyFilter)
    {
        return applyFilter
                    ? AllAsQueryable
                    : DbSet.AsQueryable();
    }

    protected virtual void AddEntityNotFoundError()
    {
        AddError("По вашему запросу запись не найдено");
    }

    protected virtual IQueryable<TEntity> InjectFilter(IQueryable<TEntity> query)
    {
        return query;
    }

    public TEntity Update(TEntity entity, bool autoSave = true)
    {
        var entry = DbSet.Update(entity);
        entry.State = EntityState.Modified;

        if (autoSave)
            Save();

        return entry.Entity;
    }
}

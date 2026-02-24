using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bms.WEBASE.EF;

public interface IDbContext
{
    ValueTask<EntityEntry> AddAsync(
        object entity,
        CancellationToken cancellationToken = default);
    EntityEntry Add(object entity);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry Entry(object entity);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    DatabaseFacade Database { get; }
    IModel Model { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<TId> CreateAndSaveAsync<TId, TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class, IHaveIdProp<TId>;
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                                     CancellationToken cancellationToken = default);
}

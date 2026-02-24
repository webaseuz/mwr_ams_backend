using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace Bms.WEBASE.EF;

public abstract class AuditableDbContext : DbContext
{
    public EfConfig Config { get; private set; }

    protected AuditableDbContext()
    { }

    public AuditableDbContext([NotNull] DbContextOptions options)
        : this(options, new EfConfig())
    { }

    public AuditableDbContext([NotNull] DbContextOptions options, EfConfig config)
        : base(options)
    {
        Config = config;
    }

    protected virtual Task<object> GetUserId() => Task.FromResult(default(object));
    protected virtual Task<bool> IsAuthenticated() => Task.FromResult(false);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (Config.AutoSetProperties.Enabled)
            await SetDefaultProperties();

        return await base.SaveChangesAsync(cancellationToken);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                                     CancellationToken cancellationToken = default)
    {
        if (Config.AutoSetProperties.Enabled)
            await SetDefaultProperties();

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                                           cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        if (Config.AutoSetProperties.Enabled)
            Task.Run(() => SetDefaultProperties());

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    private async Task SetDefaultProperties()
    {
        var userId = await GetUserId();
        bool isAuthenticated = await IsAuthenticated();

        Dictionary<string, PropertyEntry> dictionary = null;

        foreach (EntityEntry item in ChangeTracker.Entries())
        {
            switch (item.State)
            {
                case EntityState.Added:
                    dictionary = item.Properties.ToDictionary((PropertyEntry k) => k.Metadata.Name);
                    if (Config.AutoSetProperties.CreatedAt.Enabled && dictionary.TryGetValue(Config.AutoSetProperties.CreatedAt.PropertyName, out PropertyEntry propertyEntry3))
                    {
                        propertyEntry3.IsModified = false;
                        propertyEntry3.CurrentValue = DateTime.Now;
                    }

                    if (Config.AutoSetProperties.CreatedBy.Enabled && dictionary.TryGetValue(Config.AutoSetProperties.CreatedBy.PropertyName, out PropertyEntry propertyEntry4) && isAuthenticated)
                    {
                        propertyEntry4.IsModified = false;
                        propertyEntry4.CurrentValue = userId;
                    }

                    if (Config.AutoSetProperties.StateId.Enabled && dictionary.TryGetValue(Config.AutoSetProperties.StateId.PropertyName, out PropertyEntry propertyEntry5))
                    {
                        propertyEntry5.IsModified = false;
                        propertyEntry5.CurrentValue = 1;
                    }

                    dictionary.Clear();
                    break;
                case EntityState.Modified:
                    dictionary = item.Properties.ToDictionary((PropertyEntry k) => k.Metadata.Name);
                    if (Config.AutoSetProperties.ModifiedAt.Enabled && dictionary.ContainsKey(Config.AutoSetProperties.ModifiedAt.PropertyName))
                    {
                        PropertyEntry propertyEntry = dictionary[Config.AutoSetProperties.ModifiedAt.PropertyName];
                        propertyEntry.IsModified = false;
                        propertyEntry.CurrentValue = DateTime.Now;
                    }

                    if (Config.AutoSetProperties.ModifiedBy.Enabled && dictionary.ContainsKey(Config.AutoSetProperties.ModifiedBy.PropertyName) && isAuthenticated)
                    {
                        PropertyEntry propertyEntry2 = dictionary[Config.AutoSetProperties.ModifiedBy.PropertyName];
                        propertyEntry2.IsModified = false;
                        propertyEntry2.CurrentValue = userId;
                    }

                    dictionary.Clear();
                    break;
            }
        }
    }
}

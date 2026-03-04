using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class EntityRelationService(DbContext context) : IEntityRelationService
{
    public async Task<(bool HasActiveRelations, Dictionary<string, List<int>> ActiveRelationEntities)> HasActiveRelationsWithIdAsync<TEntity, TId>(
            TId entityId,
            params string[] ignoreNavigations)
            where TEntity : class, IWbStateProp
            where TId : struct
    {
        var entity = await context.Set<TEntity>().FindAsync(entityId);

        if (entity == null)
            return (false, new Dictionary<string, List<int>>());

        var entityType = context.Model.FindEntityType(typeof(TEntity));

        var navigations = entityType.GetNavigations()
            .Where(x => !ignoreNavigations.Contains(x.Name) &&
                typeof(IWbStateProp).IsAssignableFrom(x.TargetEntityType.ClrType));

        var activeIds = new Dictionary<string, List<int>>();

        foreach (var navigation in navigations)
        {
            var targetType = navigation.TargetEntityType.ClrType;

            if (navigation.IsCollection)
            {
                var query = context.Entry(entity)
                    .Collection(navigation.Name)
                    .Query();

                var activeItems = await query.Cast<IWbStateProp>()
                    .Where(e => (int)(EF.Property<int>(e, "StateId")) == WbStateIdConst.ACTIVE)
                    .Select(e => EF.Property<int>(e, "Id"))
                    .ToListAsync();

                if (activeItems.Count > 0)
                    activeIds.Add(targetType.Name, activeItems);
            }
        }

        return (activeIds.Count > 0, activeIds);
    }
}

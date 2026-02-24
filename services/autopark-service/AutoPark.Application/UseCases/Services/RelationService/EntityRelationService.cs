using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.RelationServices;

public class EntityRelationService : IEntityRelationService
{
    private readonly IWriteEfCoreContext _context;
    public EntityRelationService(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<(bool HasActiveRelations, Dictionary<string, List<int>> ActiveRelationEntities)> HasActiveRelationsWithIdAsync<TEntity, TId>(
            TId entityId,
            params string[] ignoreNavigations)
            where TEntity : class, IHaveSoftStateId
            where TId : struct
    {
        var entity = await _context.Set<TEntity>().FindAsync(entityId);

        if (entity == null)
            return (false, new Dictionary<string, List<int>>());

        var entityType = _context.Model.FindEntityType(typeof(TEntity));

        var navigations = entityType.GetNavigations()
            .Where(x => !ignoreNavigations.Contains(x.Name) &&
        typeof(IHaveSoftStateId).IsAssignableFrom(x.TargetEntityType.ClrType));

        var activeIds = new Dictionary<string, List<int>>();

        foreach (var navigation in navigations)
        {
            var targetType = navigation.TargetEntityType.ClrType;

            if (navigation.IsCollection)
            {
                var query = _context.Entry(entity)
                    .Collection(navigation.Name)
                    .Query();

                var activeItems = await query.Cast<IHaveSoftStateId>()
                    .Where(e => (int)(EF.Property<int>(e, "StateId")) == 1)
                    .Select(e => EF.Property<int>(e, "Id"))
                    .ToListAsync();
                if (activeItems.Count > 0)
                    activeIds.Add(targetType.Name, activeItems);
            }
            /*else
			{
				var query = _context.Entry(entity).Reference(navigation.Name).Query();
				var activeItem = await query.Cast<IHaveSoftStateId>()
					.Where(e => e.StateId == 1)
					.Select(e => (int?)EF.Property<int>(e, "Id"))
					.FirstOrDefaultAsync();

				if (activeItem.HasValue)
					activeIds.Add(targetType.Name, new List<int>() { activeItem.Value });
			}*/
        }

        return (activeIds.Count > 0, activeIds);
    }
}

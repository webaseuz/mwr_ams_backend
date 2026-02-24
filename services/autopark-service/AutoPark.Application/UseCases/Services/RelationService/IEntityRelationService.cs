using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.RelationServices;
public interface IEntityRelationService
{
    Task<(bool HasActiveRelations, Dictionary<string, List<int>> ActiveRelationEntities)> HasActiveRelationsWithIdAsync<TEntity, TId>(
            TId entityId,
            params string[] ignoreNavigations)
            where TEntity : class, IHaveSoftStateId
            where TId : struct;
}
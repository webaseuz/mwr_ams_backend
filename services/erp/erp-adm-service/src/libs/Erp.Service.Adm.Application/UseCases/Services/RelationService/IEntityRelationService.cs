using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public interface IEntityRelationService
{
    Task<(bool HasActiveRelations, Dictionary<string, List<int>> ActiveRelationEntities)> HasActiveRelationsWithIdAsync<TEntity, TId>(
            TId entityId,
            params string[] ignoreNavigations)
            where TEntity : class, IWbStateProp
            where TId : struct;
}

using AutoPark.Application.UseCases.RelationServices;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.OilTypes;

public class DeleteOilTypeHandler :
    IRequestHandler<DeleteOilTypeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IEntityRelationService _relationService;

    public DeleteOilTypeHandler(IWriteEfCoreContext context,
                                IEntityRelationService relationService)
    {
        _context = context;
        _relationService = relationService;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteOilTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.OilTypes
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var validateReslult = await _relationService.HasActiveRelationsWithIdAsync<OilType, int>(entity.Id);

        if (validateReslult.HasActiveRelations)
        {
            var message = FormatDictionary(validateReslult.ActiveRelationEntities);

            throw ClientLogicalExceptionHelper.CanNotPassive(message);
        }

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
    private static string FormatDictionary(Dictionary<string, List<int>> data)
    {
        return string.Join(", ", data.Select(item =>
            $"'{item.Key} - (id = {string.Join(", ", item.Value)})'"
        ));
    }
}

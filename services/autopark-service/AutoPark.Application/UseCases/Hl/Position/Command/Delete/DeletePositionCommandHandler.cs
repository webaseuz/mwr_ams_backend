using AutoPark.Application.UseCases.RelationServices;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Positions;

public class DeletePositionCommandHandler :
    IRequestHandler<DeletePositionCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IEntityRelationService _relationService;
    public DeletePositionCommandHandler(
        IWriteEfCoreContext context,
        IEntityRelationService relationService)
    {
        _relationService = relationService;
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeletePositionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Positions
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var validateReslult = await _relationService.HasActiveRelationsWithIdAsync<Position, int>(entity.Id);

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

using AutoPark.Application.UseCases.RelationServices;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportModels;

public class DeleteTransportModelHandler :
    IRequestHandler<DeleteTransportModelCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IEntityRelationService _relationService;

    public DeleteTransportModelHandler(
        IWriteEfCoreContext context,
        IEntityRelationService relationService)
    {
        _relationService = relationService;
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteTransportModelCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TransportModels
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var validateReslult = await _relationService.HasActiveRelationsWithIdAsync<TransportModel, int>(entity.Id);

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
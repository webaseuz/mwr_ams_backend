using AutoPark.Application.UseCases.RelationServices;
using AutoPark.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class DeleteContractorCommandHandler :
     IRequestHandler<DeleteContractorCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IEntityRelationService _relationService;

    public DeleteContractorCommandHandler(
        IWriteEfCoreContext context,
        IEntityRelationService relationService)
    {
        _relationService = relationService;
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteContractorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Contractors
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var validateReslult = await _relationService.HasActiveRelationsWithIdAsync<Contractor, long>(entity.Id);

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

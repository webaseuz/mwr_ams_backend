using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreatePositionCommandHandler(
    IApplicationDbContext context) : IRequestHandler<PositionCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(PositionCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Position
        {
            ShortName = request.ShortName,
            FullName = request.FullName,
            Code = request.Code,
            OrderCode = request.OrderCode,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new PositionTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName,
                TranslateText = t.TranslateText
            });

        await context.Positions.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

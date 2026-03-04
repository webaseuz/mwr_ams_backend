using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UpdatePositionCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<PositionUpdateCommand, bool>
{
    public async Task<bool> Handle(PositionUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Positions
            .Include(d => d.Translates)
            .FirstOrDefaultAsync(d => d.Id == request.Id && d.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.Code = request.Code;
        entity.OrderCode = request.OrderCode;

        context.PositionTranslates.RemoveRange(entity.Translates);
        entity.Translates.Clear();

        foreach (var t in request.Translates)
            entity.Translates.Add(new PositionTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName,
                TranslateText = t.TranslateText
            });

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

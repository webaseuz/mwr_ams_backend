using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class FuelTypeUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<FuelTypeUpdateCommand, bool>
{
    public async Task<bool> Handle(FuelTypeUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.FuelTypes
            .Include(x => x.Translates)
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.OrderCode = request.OrderCode;
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;

        context.FuelTypeTranslates.RemoveRange(entity.Translates);
        entity.Translates.Clear();

        foreach (var t in request.Translates)
            entity.Translates.Add(new FuelTypeTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

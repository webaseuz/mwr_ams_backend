using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CurrencyGetByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<CurrencyGetByIdQuery, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(CurrencyGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Currencies
            .Include(x => x.Translates)
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new CurrencyDto
            {
                Id = x.Id,
                OrderCode = x.OrderCode,
                ShortName = x.ShortName,
                FullName = x.FullName,
                Code = x.Code,
                TextCode = x.TextCode,
                PictureId = x.PictureId,
                IsMain = x.IsMain,
                StateId = x.StateId,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.LastModifiedAt,
                Translates = x.Translates.Select(t => new CurrencyTranslateDto
                {
                    ColumnName = t.ColumnName.ToString(),
                    LanguageId = t.LanguageId,
                    TranslateText = t.TranslateText
                }).ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return entity;
    }
}

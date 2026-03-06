using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class NationalityGetByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<NationalityGetByIdQuery, NationalityDto>
{
    public async Task<NationalityDto> Handle(NationalityGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Nationalities
            .Include(x => x.Translates)
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new NationalityDto
            {
                Id = x.Id,
                WbCode = x.WbCode,
                ShortName = x.ShortName,
                FullName = x.FullName,
                IsNationality = x.IsNationality,
                StateId = x.StateId,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.LastModifiedAt,
                Translates = x.Translates.Select(t => new NationalityTranslateDto
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

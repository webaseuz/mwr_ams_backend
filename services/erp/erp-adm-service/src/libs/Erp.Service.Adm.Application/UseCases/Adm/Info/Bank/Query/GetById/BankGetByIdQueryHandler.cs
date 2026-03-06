using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class BankGetByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<BankGetByIdQuery, BankDto>
{
    public async Task<BankDto> Handle(BankGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Banks
            .Include(x => x.Translates)
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new BankDto
            {
                Id = x.Id,
                OrderCode = x.OrderCode,
                Code = x.Code,
                BankCode = x.BankCode,
                FullName = x.FullName,
                ShortName = x.ShortName,
                Inn = x.Inn,
                Address = x.Address,
                Website = x.Website,
                StateId = x.StateId,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.LastModifiedAt,
                Translates = x.Translates.Select(t => new BankTranslateDto
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

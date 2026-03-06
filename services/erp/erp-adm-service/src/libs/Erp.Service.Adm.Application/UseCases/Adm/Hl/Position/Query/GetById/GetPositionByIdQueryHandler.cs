using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPositionByIdQueryHandler : IRequestHandler<PositionGetByIdQuery, PositionDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetPositionByIdQueryHandler(
        IApplicationDbContext context,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<PositionDto> Handle(PositionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Positions
            .Include(d => d.Translates)
            .Where(d => d.Id == request.Id && d.StateId == WbStateIdConst.ACTIVE)
            .Select(d => new PositionDto
            {
                Id = d.Id,
                ShortName = d.ShortName,
                FullName = d.FullName,
                Code = d.Code,
                OrderCode = d.OrderCode,
                StateId = d.StateId,
                Translates = d.Translates.Select(t => new PositionTranslateDto
                {
                    Id = t.Id,
                    OwnerId = t.OwnerId,
                    LanguageId = t.LanguageId,
                    ColumnName = t.ColumnName,
                    TranslateText = t.TranslateText
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = _localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return entity;
    }
}

using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class OrganizationGetByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<OrganizationGetByIdQuery, OrganizationDto>
{
    public async Task<OrganizationDto> Handle(OrganizationGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Organizations
            .Include(x => x.Translates)
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new OrganizationDto
            {
                Id = x.Id,
                OrderCode = x.OrderCode,
                ShortName = x.ShortName,
                FullName = x.FullName,
                Inn = x.Inn,
                ParentId = x.ParentId,
                CountryId = x.CountryId,
                RegionId = x.RegionId,
                DistrictId = x.DistrictId,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                OkedId = x.OkedId,
                Director = x.Director,
                VatCode = x.VatCode,
                ZipCode = x.ZipCode,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                StateId = x.StateId,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.LastModifiedAt,
                Translates = x.Translates.Select(t => new OrganizationTranslateDto
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

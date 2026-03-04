using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class ContractorGetByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<ContractorGetByIdQuery, ContractorDto>
{
    public async Task<ContractorDto> Handle(ContractorGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Contractors
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new ContractorDto
            {
                Id = x.Id,
                ShortName = x.ShortName,
                FullName = x.FullName,
                CountryId = x.CountryId,
                RegionId = x.RegionId,
                DistrictId = x.DistrictId,
                BankId = x.BankId,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                ContactInfo = x.ContactInfo,
                Inn = x.Inn,
                Accounter = x.Accounter,
                Director = x.Director,
                VatCode = x.VatCode,
                StateId = x.StateId,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.LastModifiedAt,
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

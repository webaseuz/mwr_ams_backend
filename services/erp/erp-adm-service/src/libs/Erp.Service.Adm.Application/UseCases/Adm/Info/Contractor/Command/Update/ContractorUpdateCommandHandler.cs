using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class ContractorUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<ContractorUpdateCommand, bool>
{
    public async Task<bool> Handle(ContractorUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Contractors
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken);

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
        entity.CountryId = request.CountryId;
        entity.RegionId = request.RegionId;
        entity.DistrictId = request.DistrictId;
        entity.BankId = request.BankId;
        entity.Address = request.Address;
        entity.PhoneNumber = request.PhoneNumber;
        entity.ContactInfo = request.ContactInfo;
        entity.Inn = request.Inn;
        entity.Accounter = request.Accounter;
        entity.Director = request.Director;
        entity.VatCode = request.VatCode;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

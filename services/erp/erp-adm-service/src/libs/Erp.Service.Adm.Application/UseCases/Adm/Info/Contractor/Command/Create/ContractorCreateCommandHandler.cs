using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class ContractorCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<ContractorCreateCommand, WbHaveId<long>>
{
    public async Task<WbHaveId<long>> Handle(ContractorCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Contractor
        {
            ShortName = request.ShortName,
            FullName = request.FullName,
            CountryId = request.CountryId,
            RegionId = request.RegionId,
            DistrictId = request.DistrictId,
            BankId = request.BankId,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            ContactInfo = request.ContactInfo,
            Inn = request.Inn,
            Accounter = request.Accounter,
            Director = request.Director,
            VatCode = request.VatCode,
            StateId = WbStateIdConst.ACTIVE
        };

        await context.Contractors.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<long>(entity.Id);
    }
}

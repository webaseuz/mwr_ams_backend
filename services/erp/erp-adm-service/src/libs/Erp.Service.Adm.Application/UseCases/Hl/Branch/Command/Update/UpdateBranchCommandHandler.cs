using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UpdateBranchCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<BranchUpdateCommand, bool>
{
    public async Task<bool> Handle(BranchUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Branches
            .FirstOrDefaultAsync(b => b.Id == request.Id && b.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.UniqueCode = request.UniqueCode;
        entity.ParentId = request.ParentId;
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.OrganizationId = request.OrganizationId;
        entity.CountryId = request.CountryId;
        entity.RegionId = request.RegionId;
        entity.DistrictId = request.DistrictId;
        entity.Address = request.Address;
        entity.Latitude = request.Latitude;
        entity.Longitude = request.Longitude;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

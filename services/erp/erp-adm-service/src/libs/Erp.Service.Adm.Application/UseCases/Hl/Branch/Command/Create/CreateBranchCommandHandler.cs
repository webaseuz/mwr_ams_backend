using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateBranchCommandHandler(
    IApplicationDbContext context,
    IMainAuthService authService) : IRequestHandler<BranchCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(BranchCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Branch
        {
            UniqueCode = request.UniqueCode,
            ParentId = request.ParentId,
            ShortName = request.ShortName,
            FullName = request.FullName,
            OrganizationId = request.OrganizationId ?? authService.CurrentOrganizationId,
            CountryId = request.CountryId,
            RegionId = request.RegionId,
            DistrictId = request.DistrictId,
            Address = request.Address,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            StateId = WbStateIdConst.ACTIVE
        };

        await context.Branches.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

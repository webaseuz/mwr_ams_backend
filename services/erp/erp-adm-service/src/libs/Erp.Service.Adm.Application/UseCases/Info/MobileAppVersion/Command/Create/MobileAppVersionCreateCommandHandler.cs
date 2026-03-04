using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class MobileAppVersionCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<MobileAppVersionCreateCommand, WbHaveId<Guid>>
{
    public async Task<WbHaveId<Guid>> Handle(MobileAppVersionCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new MobileAppVersion
        {
            FileName = request.FileName,
            VersionCode = request.VersionCode,
            Details = request.Details,
            ReleaseAt = request.ReleaseAt,
            StateId = WbStateIdConst.ACTIVE
        };

        await context.MobileAppVersions.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<Guid>(entity.Id);
    }
}

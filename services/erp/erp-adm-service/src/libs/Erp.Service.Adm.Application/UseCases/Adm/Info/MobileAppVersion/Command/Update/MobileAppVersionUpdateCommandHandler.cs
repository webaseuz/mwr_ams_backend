using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class MobileAppVersionUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<MobileAppVersionUpdateCommand, bool>
{
    public async Task<bool> Handle(MobileAppVersionUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.MobileAppVersions
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.FileName = request.FileName;
        entity.VersionCode = request.VersionCode;
        entity.Details = request.Details;
        entity.ReleaseAt = request.ReleaseAt;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

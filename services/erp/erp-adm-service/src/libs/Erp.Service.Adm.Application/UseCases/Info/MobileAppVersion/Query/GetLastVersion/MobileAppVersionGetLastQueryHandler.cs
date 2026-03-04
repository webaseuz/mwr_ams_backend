using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class MobileAppVersionGetLastQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<MobileAppVersionGetLastQuery, MobileAppVersionDto>
{
    public async Task<MobileAppVersionDto> Handle(MobileAppVersionGetLastQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.MobileAppVersions
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .OrderByDescending(x => x.ReleaseAt)
            .Select(x => new MobileAppVersionDto
            {
                Id = x.Id,
                FileName = x.FileName,
                VersionCode = x.VersionCode,
                Details = x.Details,
                ReleaseAt = x.ReleaseAt,
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
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").ToString()
                });

        return entity;
    }
}

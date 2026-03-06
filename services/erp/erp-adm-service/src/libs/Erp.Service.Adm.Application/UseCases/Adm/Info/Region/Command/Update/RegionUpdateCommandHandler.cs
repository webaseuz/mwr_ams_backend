using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RegionUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RegionUpdateCommand, bool>
{
    public async Task<bool> Handle(RegionUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Regions
            .Include(x => x.Translates)
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.OrderCode = request.OrderCode;
        entity.Code = request.Code;
        entity.Soato = request.Soato;
        entity.RoamingCode = request.RoamingCode;
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.CountryId = request.CountryId;

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

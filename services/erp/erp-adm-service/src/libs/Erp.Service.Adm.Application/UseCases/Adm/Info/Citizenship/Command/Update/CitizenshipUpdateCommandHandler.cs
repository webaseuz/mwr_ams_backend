using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CitizenshipUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<CitizenshipUpdateCommand, bool>
{
    public async Task<bool> Handle(CitizenshipUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Citizenships
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

        entity.WbCode = request.WbCode;
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.IsCitizenship = request.IsCitizenship;

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

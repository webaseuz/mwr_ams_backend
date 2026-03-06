using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class NationalityUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<NationalityUpdateCommand, bool>
{
    public async Task<bool> Handle(NationalityUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Nationalities
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
        entity.IsNationality = request.IsNationality;

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

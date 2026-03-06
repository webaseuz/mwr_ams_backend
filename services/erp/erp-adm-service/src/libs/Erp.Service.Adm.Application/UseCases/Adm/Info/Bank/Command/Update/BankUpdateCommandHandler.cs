using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class BankUpdateCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<BankUpdateCommand, bool>
{
    public async Task<bool> Handle(BankUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Banks
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
        entity.BankCode = request.BankCode;
        entity.FullName = request.FullName;
        entity.ShortName = request.ShortName;
        entity.Inn = request.Inn;
        entity.Address = request.Address;

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CurrencyCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<CurrencyCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(CurrencyCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Currency
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            Code = request.Code,
            TextCode = request.TextCode,
            PictureId = request.PictureId,
            IsMain = request.IsMain,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.Currencies.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

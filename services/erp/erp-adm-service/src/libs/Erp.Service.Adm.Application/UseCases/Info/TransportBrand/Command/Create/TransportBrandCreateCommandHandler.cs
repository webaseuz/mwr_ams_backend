using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportBrandCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<TransportBrandCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(TransportBrandCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new TransportBrand
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.TransportBrands.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

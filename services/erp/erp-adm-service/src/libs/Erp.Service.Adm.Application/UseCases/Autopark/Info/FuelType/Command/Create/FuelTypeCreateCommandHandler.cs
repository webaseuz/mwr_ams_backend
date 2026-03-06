using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class FuelTypeCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<FuelTypeCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(FuelTypeCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new FuelType
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.FuelTypes.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportColorCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<TransportColorCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(TransportColorCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new TransportColor
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.TransportColors.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

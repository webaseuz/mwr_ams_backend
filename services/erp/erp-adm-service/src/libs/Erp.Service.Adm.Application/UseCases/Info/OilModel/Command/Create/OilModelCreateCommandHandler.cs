using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class OilModelCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<OilModelCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(OilModelCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new OilModel
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            OilTypeId = request.OilTypeId,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.OilModels.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

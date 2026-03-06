using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TireSizeCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<TireSizeCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(TireSizeCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new TireSize
        {
            OrderCode = request.OrderCode,
            Width = request.Width,
            Height = request.Height,
            Radius = request.Radius,
            StateId = WbStateIdConst.ACTIVE
        };

        await context.TireSizes.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

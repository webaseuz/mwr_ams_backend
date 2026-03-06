using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CountryCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<CountryCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Country
        {
            OrderCode = request.OrderCode,
            Code = request.Code,
            TextCode = request.TextCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.Countries.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

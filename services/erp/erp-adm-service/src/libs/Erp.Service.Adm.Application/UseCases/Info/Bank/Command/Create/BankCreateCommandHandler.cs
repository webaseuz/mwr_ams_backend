using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class BankCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<BankCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(BankCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Bank
        {
            OrderCode = request.OrderCode,
            Code = request.Code,
            BankCode = request.BankCode,
            FullName = request.FullName,
            ShortName = request.ShortName,
            Inn = request.Inn,
            Address = request.Address,
            Website = request.Website,
            StateId = WbStateIdConst.ACTIVE
        };

        request.Translates.AddByUniqueFKTo(entity.Translates);

        await context.Banks.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

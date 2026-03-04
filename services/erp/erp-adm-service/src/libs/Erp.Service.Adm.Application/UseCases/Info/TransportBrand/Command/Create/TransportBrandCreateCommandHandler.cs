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

        foreach (var t in request.Translates)
            entity.Translates.Add(new TransportBrandTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.TransportBrands.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

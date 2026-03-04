using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DistrictCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<DistrictCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(DistrictCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new District
        {
            OrderCode = request.OrderCode,
            Code = request.Code,
            Soato = request.Soato,
            RoamingCode = request.RoamingCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            RegionId = request.RegionId,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new DistrictTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.Districts.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

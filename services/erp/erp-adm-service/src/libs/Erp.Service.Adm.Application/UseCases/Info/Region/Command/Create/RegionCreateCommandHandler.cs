using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RegionCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<RegionCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(RegionCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Region
        {
            OrderCode = request.OrderCode,
            Code = request.Code,
            Soato = request.Soato,
            RoamingCode = request.RoamingCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            CountryId = request.CountryId,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new RegionTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.Regions.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

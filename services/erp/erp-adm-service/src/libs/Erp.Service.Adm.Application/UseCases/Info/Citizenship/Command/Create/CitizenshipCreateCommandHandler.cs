using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CitizenshipCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<CitizenshipCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(CitizenshipCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Citizenship
        {
            WbCode = request.WbCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            IsCitizenship = request.IsCitizenship,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new CitizenshipTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.Citizenships.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

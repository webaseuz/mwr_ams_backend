using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class NationalityCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<NationalityCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(NationalityCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Nationality
        {
            WbCode = request.WbCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            IsNationality = request.IsNationality,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new NationalityTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.Nationalities.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}

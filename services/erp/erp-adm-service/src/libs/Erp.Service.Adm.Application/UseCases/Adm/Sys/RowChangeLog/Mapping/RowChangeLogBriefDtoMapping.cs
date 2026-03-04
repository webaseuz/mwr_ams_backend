using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application;
public class RowChangeLogBriefDtoMapping : CultureProfile
{
    public RowChangeLogBriefDtoMapping()
    {
        var cultureId = 1;

        CreateMap<RowChangeLog, RowChangeLogBriefDto>()
            .ForMember(x => x.Table, x => x.MapFrom(ent => ent.Table.Translates.AsQueryable().FirstOrDefault(TableTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.Table.FullName ?? ""))
             .ForMember(x => x.DateAt, x => x.MapFrom(ent => ent.DateAt.ToString("dd.MM.yyyy HH:mm:ss"))); ;
    }
}

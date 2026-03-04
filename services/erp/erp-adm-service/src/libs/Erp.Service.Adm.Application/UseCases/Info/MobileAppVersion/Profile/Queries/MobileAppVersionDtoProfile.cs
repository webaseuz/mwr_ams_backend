using Erp.Core.Service.Application;
using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class MobileAppVersionDtoProfile : CultureProfile
{
    public MobileAppVersionDtoProfile()
    {
        var cultureId = 1;

        CreateMap<MobileAppVersion, MobileAppVersionDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
            lang)).TranslateText ?? ent.State.FullName));
    }
}

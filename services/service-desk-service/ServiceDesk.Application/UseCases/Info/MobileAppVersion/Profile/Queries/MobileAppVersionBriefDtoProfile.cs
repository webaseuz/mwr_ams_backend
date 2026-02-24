using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class MobileAppVersionBriefDtoProfile :
    Profile
{
    public MobileAppVersionBriefDtoProfile()
    {
        int lang = default;

        CreateMap<MobileAppVersion, MobileAppVersionBriefDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
            lang)).TranslateText ?? ent.State.FullName));
    }
}

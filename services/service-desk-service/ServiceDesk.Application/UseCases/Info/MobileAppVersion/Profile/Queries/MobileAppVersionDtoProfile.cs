using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class MobileAppVersionDtoProfile :
    Profile
{
    public MobileAppVersionDtoProfile()
    {
        int lang = default;

        CreateMap<MobileAppVersion, MobileAppVersionDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
            lang)).TranslateText ?? ent.State.FullName));
    }
}

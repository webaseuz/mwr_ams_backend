using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Roles;

public class RoleTranslateDtoProfile : Profile
{
    public RoleTranslateDtoProfile()
    {
        CreateMap<RoleTranslate, RoleTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

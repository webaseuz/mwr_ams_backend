using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Roles;

public class RoleTranslateDtoProfile : Profile
{
    public RoleTranslateDtoProfile()
    {
        CreateMap<RoleTranslate, RoleTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

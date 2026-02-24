using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentTranslateDtoProfile : Profile
{
    public DepartmentTranslateDtoProfile()
    {
        CreateMap<DepartmentTranslate, DepartmentTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class ServiceTypeTranslateDtoProfile : Profile
{
    public ServiceTypeTranslateDtoProfile()
    {
        CreateMap<ServiceTypeTranslate, ServiceTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

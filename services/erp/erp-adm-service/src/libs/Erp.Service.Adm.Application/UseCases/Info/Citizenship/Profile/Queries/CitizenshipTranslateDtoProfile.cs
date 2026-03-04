using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class CitizenshipTranslateDtoProfile : Profile
{
    public CitizenshipTranslateDtoProfile()
    {
        CreateMap<CitizenshipTranslate, CitizenshipTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
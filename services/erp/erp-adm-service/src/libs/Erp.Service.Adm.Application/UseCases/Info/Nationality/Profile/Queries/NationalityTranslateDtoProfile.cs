using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NationalityTranslateDtoProfile : Profile
{
    public NationalityTranslateDtoProfile()
    {
        CreateMap<NationalityTranslate, NationalityTranslateDto>()
            .ForMember(src => src.Language, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

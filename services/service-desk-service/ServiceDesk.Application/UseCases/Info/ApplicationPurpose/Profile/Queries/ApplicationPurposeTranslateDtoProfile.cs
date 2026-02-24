using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class ApplicationPurposeTranslateDtoProfile : Profile
{
    public ApplicationPurposeTranslateDtoProfile()
    {
        CreateMap<ApplicationPurposeTranslate,ApplicationPurposeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

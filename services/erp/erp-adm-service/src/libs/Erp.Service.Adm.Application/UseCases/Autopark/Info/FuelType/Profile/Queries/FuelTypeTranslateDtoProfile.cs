using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class FuelTypeTranslateDtoProfile : Profile
{
    public FuelTypeTranslateDtoProfile()
    {
        CreateMap<FuelTypeTranslate, FuelTypeTranslateDto>()
            .ForMember(src => src.Language, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

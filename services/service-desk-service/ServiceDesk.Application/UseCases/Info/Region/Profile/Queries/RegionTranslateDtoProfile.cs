using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionTranslateDtoProfile : Profile
{
    public RegionTranslateDtoProfile()
    {
        CreateMap<RegionTranslate, RegionTranslateDto>()
            ;
    }
}

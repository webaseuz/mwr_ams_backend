using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Regions;

public class RegionTranslateDtoProfile : Profile
{
    public RegionTranslateDtoProfile()
    {
        CreateMap<RegionTranslate, RegionTranslateDto>()
            ;
    }
}

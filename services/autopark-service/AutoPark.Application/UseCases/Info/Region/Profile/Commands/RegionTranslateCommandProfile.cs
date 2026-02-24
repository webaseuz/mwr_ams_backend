using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Regions;

public class RegionTranslateCommandProfile :
    Profile
{
    public RegionTranslateCommandProfile()
    {
        CreateMap<RegionTranslateCommand, RegionTranslate>();
    }
}

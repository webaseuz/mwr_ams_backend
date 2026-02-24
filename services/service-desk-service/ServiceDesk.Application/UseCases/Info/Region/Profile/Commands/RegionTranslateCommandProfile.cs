using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionTranslateCommandProfile : 
	Profile
{
    public RegionTranslateCommandProfile()
    {
        CreateMap<RegionTranslateCommand, RegionTranslate>();
    }
}

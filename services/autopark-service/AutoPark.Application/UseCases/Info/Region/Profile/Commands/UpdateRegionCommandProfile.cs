using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Regions;

public class UpdateRegionCommandProfile :
    Profile
{
    public UpdateRegionCommandProfile()
    {
        CreateMap<UpdateRegionCommand, Region>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

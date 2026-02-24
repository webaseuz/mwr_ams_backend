using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Regions;

public class CreateRegionCommandProfile :
    Profile
{
    public CreateRegionCommandProfile()
    {
        CreateMap<CreateRegionCommand, Region>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

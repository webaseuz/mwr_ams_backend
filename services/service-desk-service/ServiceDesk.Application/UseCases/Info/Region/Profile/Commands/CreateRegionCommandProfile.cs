using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Regions;

public class CreateRegionCommandProfile : 
	Profile
{
    public CreateRegionCommandProfile()
    {
        CreateMap<CreateRegionCommand, Region>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

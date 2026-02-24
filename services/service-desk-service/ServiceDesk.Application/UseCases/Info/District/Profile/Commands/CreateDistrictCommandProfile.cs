using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Districts;

public class CreateDistrictCommandProfile : Profile
{
    public CreateDistrictCommandProfile()
    {
        CreateMap<CreateDistrictCommand, District>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

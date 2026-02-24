using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Districts;

public class CreateDistrictCommandProfile : Profile
{
    public CreateDistrictCommandProfile()
    {
        CreateMap<CreateDistrictCommand, District>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

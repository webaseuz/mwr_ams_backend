using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Districts;

public class UpdateDistrictCommandProfile : Profile
{
    public UpdateDistrictCommandProfile()
    {
        CreateMap<UpdateDistrictCommand, District>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Districts;

public class UpdateDistrictCommandProfile : Profile
{
    public UpdateDistrictCommandProfile()
    {
        CreateMap<UpdateDistrictCommand, District>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

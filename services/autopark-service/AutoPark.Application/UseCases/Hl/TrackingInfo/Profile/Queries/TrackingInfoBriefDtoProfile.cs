using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class TrackingInfoBriefDtoProfile : Profile
{
    public TrackingInfoBriefDtoProfile()
    {
        CreateMap<TrackingInfo, TrackingInfoBriefDto>()
            .ForMember(src => src.PersonName, conf => conf.MapFrom(ent => ent.Person.FullName));
    }
}

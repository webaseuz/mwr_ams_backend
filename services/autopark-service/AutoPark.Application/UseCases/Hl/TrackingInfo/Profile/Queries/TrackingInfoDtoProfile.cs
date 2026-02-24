using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class TrackingInfoDtoProfile : Profile
{
    public TrackingInfoDtoProfile()
    {
        CreateMap<TrackingInfo, TrackingInfoDto>();
    }
}

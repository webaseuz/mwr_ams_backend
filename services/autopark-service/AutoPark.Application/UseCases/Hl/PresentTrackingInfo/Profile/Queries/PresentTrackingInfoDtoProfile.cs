using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class PresentTrackingInfoDtoProfile : Profile
{
    public PresentTrackingInfoDtoProfile()
    {
        CreateMap<PresentTrackingInfo, PresentTrackingInfoDto>();
    }
}

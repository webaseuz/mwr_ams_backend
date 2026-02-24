using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class PresentTrackingInfoBriefDtoProfile : Profile
{
    public PresentTrackingInfoBriefDtoProfile()
    {
        CreateMap<PresentTrackingInfo, PresentTrackingInfoBriefDto>();
    }
}

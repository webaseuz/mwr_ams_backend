using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class CreatePresentTrackingInfoCommandProfile : Profile
{
    public CreatePresentTrackingInfoCommandProfile()
    {
        CreateMap<CreatePresentTrackingInfoCommand, PresentTrackingInfo>();
    }
}

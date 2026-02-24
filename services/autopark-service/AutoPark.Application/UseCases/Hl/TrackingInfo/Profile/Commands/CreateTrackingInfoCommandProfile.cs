using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class CreateTrackingInfoCommandProfile : Profile
{
    public CreateTrackingInfoCommandProfile()
    {
        CreateMap<CreateTrackingInfoCommand, TrackingInfo>();
    }
}

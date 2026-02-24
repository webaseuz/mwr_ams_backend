using AutoMapper;
using AutoPark.Application.UseCases.PresentTrackingInfos;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class DriverAndTransportInfoDtoProfile : Profile
{
    public DriverAndTransportInfoDtoProfile()
    {
        // Person -> DTO mapping
        CreateMap<Person, DriverAndTransportInfoDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.BranchName, opt => opt.Ignore()) // Keyinroq to'ldiramiz
            .ForMember(dest => dest.StateNumber, opt => opt.Ignore())
            .ForMember(dest => dest.TransportModel, opt => opt.Ignore())
            .ForMember(dest => dest.TransportBrand, opt => opt.Ignore())
            .ForMember(dest => dest.TransportColorId, opt => opt.Ignore())
            .ForMember(dest => dest.TransportColor, opt => opt.Ignore());

        // Transport -> DTO mapping
        CreateMap<Transport, DriverAndTransportInfoDto>()
            .ForMember(dest => dest.StateNumber, opt => opt.MapFrom(src => src.StateNumber))
            .ForMember(dest => dest.TransportModel, opt => opt.MapFrom(src => src.TransportModel.FullName))
            .ForMember(dest => dest.TransportBrand, opt => opt.MapFrom(src => src.TransportBrand.FullName))
            .ForMember(dest => dest.TransportColorId, opt => opt.MapFrom(src => src.TransportColorId))
            .ForMember(dest => dest.TransportColor, opt => opt.MapFrom(src => src.TransportColor.FullName));
    }
}
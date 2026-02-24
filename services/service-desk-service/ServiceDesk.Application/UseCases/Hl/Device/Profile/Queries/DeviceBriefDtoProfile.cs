using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class DeviceBriefDtoProfile : Profile
{
    public DeviceBriefDtoProfile()
    {
        //DeviceBriefDto
        CreateMap<Device, DeviceBriefDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName))
            .ForMember(src => src.DeviceTypeName, conf => conf.MapFrom(x => x.DeviceType.FullName))
            .ForMember(src => src.DeviceModelName, conf => conf.MapFrom(x => x.DeviceModel.FullName))
            .ForMember(src => src.ManufacturerName, conf => conf.MapFrom(x => x.Manufacturer.FullName))
            .ForMember(src => src.ServiceContractorName, conf => conf.MapFrom(x => x.ServiceContractor.FullName))
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(x => x.ResponsiblePerson.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(x => x.Branch.FullName))
            ;
    }
}

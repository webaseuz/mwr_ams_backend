using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingInspectionDtoProfile : Profile
{
    public TransportSettingInspectionDtoProfile()
    {
        CreateMap<TransportSettingInspection, TransportSettingInspectionDto>()
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName));
    }
}

using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingInspectionDtoProfile : Profile
{
    public TransportSettingInspectionDtoProfile()
    {
        CreateMap<TransportSettingInspection, TransportSettingInspectionDto>()
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName));
    }
}

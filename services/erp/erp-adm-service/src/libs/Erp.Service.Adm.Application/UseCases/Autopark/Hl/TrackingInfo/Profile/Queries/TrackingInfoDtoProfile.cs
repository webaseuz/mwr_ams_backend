using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TrackingInfoDtoProfile : Profile
{
    public TrackingInfoDtoProfile()
    {
        CreateMap<TrackingInfo, TrackingInfoDto>()
            .ForMember(src => src.PersonName, conf => conf.MapFrom(ent => ent.Person.FullName));
    }
}

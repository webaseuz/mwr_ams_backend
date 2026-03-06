using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class FuelCardDtoProfile : Profile
{
    public FuelCardDtoProfile()
    {
        CreateMap<FuelCard, FuelCardDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName))
            .ForMember(src => src.PlasticCardTypeName, conf => conf.MapFrom(ent => ent.PlasticCardType.FullName))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.FullName))
            .ForMember(src => src.TransportStateNumber, conf => conf.MapFrom(ent => ent.Transport.StateNumber))
            .ForMember(src => src.ExpireAt, conf => conf.MapFrom(src => src.ExpireAt.HasValue ? src.ExpireAt.Value.ToString("MM/yy") : string.Empty))
            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.Transport.TransportModel.FullName));
    }
}

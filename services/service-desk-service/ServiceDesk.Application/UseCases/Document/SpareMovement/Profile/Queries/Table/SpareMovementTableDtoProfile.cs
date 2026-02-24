using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class SpareMovementTableDtoProfile : Profile
{
    public SpareMovementTableDtoProfile()
    {
        CreateMap<SpareMovementTable, SpareMovementTableDto>()
            .ForMember(ent => ent.DeviceSpareTypeName, conf => conf.MapFrom(ent => ent.DeviceSpareType.FullName));
    }
}

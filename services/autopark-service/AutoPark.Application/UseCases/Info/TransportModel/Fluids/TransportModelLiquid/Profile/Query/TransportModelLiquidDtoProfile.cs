using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelLiquidDtoProfile : Profile
{
    public TransportModelLiquidDtoProfile()
    {
        CreateMap<TransportModelLiquid, TransportModelLiquidDto>();
    }
}

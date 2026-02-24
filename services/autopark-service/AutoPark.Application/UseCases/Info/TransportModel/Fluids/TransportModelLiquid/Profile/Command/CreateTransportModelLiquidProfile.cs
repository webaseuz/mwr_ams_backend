using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelLiquidProfile : Profile
{
    public CreateTransportModelLiquidProfile()
    {
        CreateMap<CreateTransportModelLiquidCommand, TransportModelLiquid>();
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelLiquidProfile : Profile
{
    public UpdateTransportModelLiquidProfile()
    {
        CreateMap<UpdateTransportModelLiquidCommand, TransportModelLiquid>();
    }
}

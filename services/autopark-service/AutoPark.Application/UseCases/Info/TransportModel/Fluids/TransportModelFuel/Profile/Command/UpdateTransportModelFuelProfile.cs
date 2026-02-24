using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelFuelProfile : Profile
{
    public UpdateTransportModelFuelProfile()
    {
        CreateMap<UpdateTransportModelFuelCommand, TransportModelFuel>();
    }
}

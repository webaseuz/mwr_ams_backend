using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelFuelProfile : Profile
{
    public CreateTransportModelFuelProfile()
    {
        CreateMap<CreateTransportModelFuelCommand, TransportModelFuel>();
    }
}

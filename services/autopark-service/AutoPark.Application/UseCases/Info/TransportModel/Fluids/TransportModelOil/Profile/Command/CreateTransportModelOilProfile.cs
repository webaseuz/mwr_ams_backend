using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelOilProfile : Profile
{
    public CreateTransportModelOilProfile()
    {
        CreateMap<CreateTransportModelOilCommand, TransportModelOil>();
    }
}
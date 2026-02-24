using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelOilProfile : Profile
{
    public UpdateTransportModelOilProfile()
    {
        CreateMap<UpdateTransportModelOilCommand, TransportModelOil>();
    }
}


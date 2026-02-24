using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelCommandProfile :
    Profile
{
    public CreateTransportModelCommandProfile()
    {
        CreateMap<CreateTransportModelCommand, TransportModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore())
            .ForMember(src => src.Liquids, conf => conf.Ignore())
            .ForMember(src => src.Fuels, conf => conf.Ignore())
            .ForMember(src => src.Oils, conf => conf.Ignore())
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}

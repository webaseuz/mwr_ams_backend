using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class UpdateTransportUseTypeCommandProfile :
    Profile
{
    public UpdateTransportUseTypeCommandProfile()
    {
        CreateMap<UpdateTransportUseTypeCommand, TransportUseType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

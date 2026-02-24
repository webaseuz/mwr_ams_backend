using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class UpdateServiceTypeCommandProfile : Profile
{
    public UpdateServiceTypeCommandProfile()
    {
        CreateMap<UpdateServiceTypeCommand, ServiceType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

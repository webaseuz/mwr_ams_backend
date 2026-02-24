using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class CreateServiceTypeCommandProfile : Profile
{
    public CreateServiceTypeCommandProfile()
    {
        CreateMap<CreateServiceTypeCommand, ServiceType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class ServiceTypeTranslateCommandProfile : Profile
{
    public ServiceTypeTranslateCommandProfile()
    {
        CreateMap<ServiceTypeTranslateCommand, ServiceTypeTranslate>();
    }
}

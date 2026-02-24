using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationFileDtoProfile : Profile
{
    public ServiceApplicationFileDtoProfile()
    {
        CreateMap<ServiceApplicationFile, ServiceApplicationFileDto>();
    }
}

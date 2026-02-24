using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationExecutorFileDtoProfile : Profile
{
	public ServiceApplicationExecutorFileDtoProfile()
	{
        CreateMap<ServiceApplicationExecutorFile, ServiceApplicationExecutorFileDto>();
    }
}

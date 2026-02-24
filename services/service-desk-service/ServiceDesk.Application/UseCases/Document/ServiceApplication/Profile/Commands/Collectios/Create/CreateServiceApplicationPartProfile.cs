using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationPartProfile : Profile
{
	public CreateServiceApplicationPartProfile()
	{
		CreateMap<CreateServiceApplicationPartCommand, ServiceApplicationPart>();
        CreateMap<ServiceApplicationPartDto, ServiceApplicationPart>();
    }
}

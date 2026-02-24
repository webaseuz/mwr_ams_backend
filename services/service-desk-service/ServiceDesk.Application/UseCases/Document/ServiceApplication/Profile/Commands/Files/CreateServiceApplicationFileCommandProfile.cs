using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationFileCommandProfile : Profile
{
	public CreateServiceApplicationFileCommandProfile()
	{
		CreateMap<CreateServiceApplicationFileCommand, ServiceApplicationFile>();
	}
}

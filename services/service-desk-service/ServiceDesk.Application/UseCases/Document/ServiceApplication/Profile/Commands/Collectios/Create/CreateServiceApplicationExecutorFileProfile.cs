using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationExecutorFileProfile : Profile
{
	public CreateServiceApplicationExecutorFileProfile()
	{
		CreateMap<CreateServiceApplicationExecutorFileCommand, ServiceApplicationExecutorFile>();
	}
}

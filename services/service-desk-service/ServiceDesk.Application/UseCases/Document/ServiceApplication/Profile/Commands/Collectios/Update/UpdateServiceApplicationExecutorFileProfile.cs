using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationExecutorFileProfile : Profile
{
	public UpdateServiceApplicationExecutorFileProfile()
	{
		CreateMap<UpdateServiceApplicationExecutorFileCommand, ServiceApplicationExecutorFile>();
	}
}

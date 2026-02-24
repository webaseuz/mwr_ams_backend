using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationFileCommandProfile : Profile
{
	public UpdateServiceApplicationFileCommandProfile()
	{
		CreateMap<UpdateServiceApplicationFileCommand, ServiceApplication>();
	}
}
